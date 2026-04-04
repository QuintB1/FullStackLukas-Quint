using ChampionsLeague.Domain.Data;
using ChampionsLeague.Domain.Entities;
using ChampionsLeague.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ChampionsLeague.Repository
{
    public class OrderLineDAO : IDAO<OrderLine>
    {
        private readonly DbContextChampionsLeague _context;

        public OrderLineDAO(DbContextChampionsLeague context)
        {
            _context = context;
        }

        public async Task AddAsync(OrderLine entity)
        {
            await _context.OrderLines.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(OrderLine entity)
        {
            _context.OrderLines.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<OrderLine>?> GetAllAsync()
        {
            return await _context.OrderLines.ToListAsync();
        }

        public async Task UpdateAsync(OrderLine entity)
        {
            _context.OrderLines.Update(entity);
            await _context.SaveChangesAsync();
        }
        // overload function nessisary to ratin interface DO NOT REMOVE!
        Task<OrderLine?> IDAO<OrderLine>.FindByAsync(int id)
        {
            throw new NotSupportedException("OrderLine requires composite key.");
        }

        public async Task<OrderLine?> FindByAsync(int orderId, int lineNumber)
        {
            return await _context.OrderLines
                .FirstOrDefaultAsync(ol => ol.OrderId == orderId && ol.LineId == lineNumber);
        }


    }
}
