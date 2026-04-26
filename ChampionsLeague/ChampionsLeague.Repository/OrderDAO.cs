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

        public async Task<Order> GetUserShoppingCart(String id)
        {
            return _context.Orders.Where(c => c.UserId.Equals(id) && c.Status.Equals("Cart")).FirstOrDefault();
        }

        public async Task UpdateAsync(Order entity)
        {
            _context.Orders.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
