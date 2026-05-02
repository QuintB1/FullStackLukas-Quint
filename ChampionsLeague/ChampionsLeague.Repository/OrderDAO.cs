using ChampionsLeague.Domain.DataDB;
using ChampionsLeague.Domain.EntitiesDB;
using ChampionsLeague.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ChampionsLeague.Repository
{
    public class OrderDAO : IOrderDAO
    {
        private readonly ChampionLeagueDbContext _context;

        public OrderDAO(ChampionLeagueDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Order entity)
        {
            await _context.Orders.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task AddSubscriptionToCart(int clubId, string userId)
        {
            // Step 1: Find the subscription product for this club
            var productId = await _context.Subscriptions
                .Where(s => s.ClubId == clubId)
                .Select(p => p.ProductId)
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


        public  async Task AddTicketToCart(int matchId, string userId)
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



        public async Task UpdateAsync(Order entity)
        {
            _context.Orders.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePriceAsync(String userId)
        {
            var id = _context.Orders.Where(o =>  o.UserId == userId && o.Status == "Cart").Select(o => o.OrderId).FirstOrDefault();
            if(id == 0)
            {
                throw new KeyNotFoundException("cart not found");
            }

            await _context.Database.ExecuteSqlRawAsync(
             "EXEC UpdateOrderLineStaticPrices @p0",
             id);
        }
    }
}
