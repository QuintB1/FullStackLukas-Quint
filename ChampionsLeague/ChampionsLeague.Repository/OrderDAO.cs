using ChampionsLeague.Domain.DataDB;
using ChampionsLeague.Domain.EntitiesDB;
using ChampionsLeague.Repository.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace ChampionsLeague.Repository
{
    public class OrderDAO : IOrderDAO
    {
        private readonly ChampionLeagueDbContext _context;

        public OrderDAO(ChampionLeagueDbContext context)
        {
            _context = context;
        }

        public async Task AddSubscriptionToCart(int clubId, string userId)
        {
            try
            {
                // Step 1: Find the subscription product for this club
                var productId = await _context.Subscriptions
                    .Where(s => s.ClubId == clubId)
                    .Select(s => s.ProductId)
                    .FirstOrDefaultAsync();

                if (productId == 0)
                    throw new KeyNotFoundException($"No subscription product found for ClubId {clubId}");

                // Step 2: Call the stored procedure
                await _context.Database.ExecuteSqlRawAsync(
                    "EXEC AddProductToCart @UserID = {0}, @ProductID = {1}",
                    userId,
                    productId
                );
            }
            catch
            {
                throw;
            }
        }


        public async Task AddTicketToCart(int matchId, string userId)
        {
            var productId = await _context.Tickets
                .Where(t => t.MatchId == matchId)
                .Select(t => t.ProductId).FirstOrDefaultAsync();
            if(productId == 0)
            {
                throw new KeyNotFoundException("no product found for match");
            }
            await _context.Database.ExecuteSqlRawAsync(
                "EXEC AddProductToCart @UserID = {0}, @ProductID = {1}",
                userId,
                productId
            );

        }

        public async Task DeleteAsync(Order entity)
        {
            _context.Orders.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<Order?> FindByAsync(int id)
        {
            return await _context.Orders.FindAsync(id);
        }

        public async Task<IEnumerable<Order>?> GetAllAsync()
        {
            return await _context.Orders.ToListAsync();
        }

        public async Task<Order?> GetUserShoppingCart(string userId)
        {
            return await _context.Orders
                .Include(o => o.OrderLines)
                    .ThenInclude(ol => ol.Product)
                .FirstOrDefaultAsync(o => o.UserId == userId && o.Status == "Cart");
        }

        public async Task RemoveFromCart(int lineId, string userId)
        {
            var line = await _context.OrderLines.Include(ol => ol.Order)
                .FirstAsync(ol => ol.LineId == lineId && ol.Order.UserId == userId);

            if (line == null)
            {
                return;
            }

            _context.OrderLines.Remove(line);
            await _context.SaveChangesAsync();
        }

        public async Task<Order?> GetUserPaidOrders(string userId)
        {
            return await _context.Orders
                .Include(o => o.OrderLines)
                    .ThenInclude(ol => ol.Product)
                .FirstOrDefaultAsync(o => o.UserId == userId && o.Status == "Paid");
        }

        public async Task UpdateAsync(Order entity)
        {
            _context.Orders.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<StadiumSection>> GetSectionsForProduct(int productId)
        {
            // 1. Try to load as a ticket product
            var ticket = await _context.Tickets
                .Include(t => t.Match)
                .FirstOrDefaultAsync(t => t.ProductId == productId);

            int stadiumId = 0;

            if (ticket != null)
            {
                // Ticket → Match → Stadium
                if (ticket.Match == null)
                    throw new KeyNotFoundException($"Match not found for Ticket ProductId {productId}");

                stadiumId = ticket.Match.StadiumId;
            }
            else
            {
                // 2. Try to load as a subscription product
                var subscription = await _context.Subscriptions
                    .Include(s => s.Club)
                    .FirstOrDefaultAsync(s => s.ProductId == productId);

                if (subscription == null)
                    throw new KeyNotFoundException($"ProductId {productId} is neither a ticket nor a subscription");

                if (subscription.Club == null)
                    throw new KeyNotFoundException($"Club not found for Subscription ProductId {productId}");

                // Subscription → Club → HomeStadium
                stadiumId = (int)subscription.Club.HomeStadiumId;
            }

            if (stadiumId == 0)
                throw new KeyNotFoundException($"No stadium found for ProductId {productId}");

            // 3. Load sections for the stadium
            return await _context.StadiumSections
                .Where(s => s.StadiumId == stadiumId)
                .ToListAsync();
        }
        public async Task UpdateCart(Order order, string userId)
        {
            var dbOrder = await _context.Orders
                .Include(o => o.OrderLines)
                .FirstOrDefaultAsync(o => o.OrderId == order.OrderId && o.UserId == userId);

            if (dbOrder == null)
                throw new Exception("Cart not found");

            foreach (var updatedLine in order.OrderLines)
            {
                var line = dbOrder.OrderLines.First(l => l.LineId == updatedLine.LineId);

                line.Quantity = updatedLine.Quantity;
                line.StadiumSectionId = updatedLine.StadiumSectionId;
            }

            await _context.SaveChangesAsync();
        }

        public async Task Checkout(int orderId)
        {
            await _context.Database.ExecuteSqlRawAsync(
             "EXEC FinalizeOrderAndAssignSeats @p0",
             orderId);
        }

        public async Task CancelTicket(int assignmentId)
        {
            await _context.Database.ExecuteSqlRawAsync(
             "EXEC CancelTicketAssignmentByID @p0",
             assignmentId);
        }

        public async Task CancelSubscription(int assignmentId)
        {
            await _context.Database.ExecuteSqlRawAsync(
             "EXEC CancelSubscriptionAssignmentByID @p0",
             assignmentId);
        }

        public async Task<List<Order>> GetHistory(string userId)
        {
            return await _context.Orders
                .Include(o => o.OrderLines)
                .ThenInclude(ol => ol.Product)
                .Where(o => o.UserId == userId && o.Status == "Paid").ToListAsync();
        }

        public async Task<List<TicketAssignment>> GetValidTicketAssignments(string userId)
        {
            var today = DateTime.UtcNow;
            return await _context.TicketAssignments
                .Include(t => t.Ticket)
                .ThenInclude(t => t.Match)
                .Where(t => t.Active == true && t.Ticket.Match.DateTime < today)
                .Where(t => t.UserId == userId)
                .ToListAsync();
        }

        public async Task<List<SubscriptionAssignment>> GetValidSubscriptionAssignments(string userId)
        {
            var today = DateOnly.FromDateTime(DateTime.Today);

            return await _context.SubscriptionAssignments
                .Include(s => s.Subscription)
                .ThenInclude(sub => sub.Season)
                .Where(s => s.UserId == userId)
                .Where(s => s.Subscription.Season.EndDate >= today)
                .ToListAsync();
        }

    }
}
