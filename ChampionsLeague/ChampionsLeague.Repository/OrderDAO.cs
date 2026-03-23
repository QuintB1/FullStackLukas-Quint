using ChampionsLeague.Domain.Data;
using ChampionsLeague.Domain.Entities;
using ChampionsLeague.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChampionsLeague.Repository
{
    public class OrderDAO : IDAO<Order>
    {
        private readonly DbContextChampionsLeague _context;

        public OrderDAO(DbContextChampionsLeague context) {
            _context = context;
        }

        public Task AddAsync(Order entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Order entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Order>?> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Order entity)
        {
            throw new NotImplementedException();
        }

        Task<Order?> IDAO<Order>.FindByAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
