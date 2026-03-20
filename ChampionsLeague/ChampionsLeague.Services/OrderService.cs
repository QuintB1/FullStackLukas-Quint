using ChampionsLeague.Domain.EntitiesDB;
using ChampionsLeague.Repository.Interfaces;
using ChampionsLeague.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChampionsLeague.Services
{
    public class OrderService : IService<Order>
    {
        private readonly IDAO<Order> _orderDAO;
    
        public OrderService(IDAO<Order> DAO)
        {
            _orderDAO = DAO;
        }
        public Task AddAsync(Order entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Order entity)
        {
            throw new NotImplementedException();
        }

        public Task<Order?> FindByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Order>?> GetAllAsync()
        {
            return await _orderDAO.GetAllAsync();
        }

        public Task UpdateAsync(Order entity)
        {
            throw new NotImplementedException();
        }

        Task<Order?> IService<Order>.FindByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
