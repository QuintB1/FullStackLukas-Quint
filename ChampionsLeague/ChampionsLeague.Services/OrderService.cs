using ChampionsLeague.Domain.Entities;
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
            return _orderDAO.AddAsync(entity);
        }

        public Task DeleteAsync(Order entity)
        {
            return _orderDAO.DeleteAsync(entity);
        }

        public Task<Order?> FindByIdAsync(int Id)
        {
            return _orderDAO.FindByAsync(Id);
        }

        public async Task<IEnumerable<Order>?> GetAllAsync()
        {
            return await _orderDAO.GetAllAsync();
        }

        public Task UpdateAsync(Order entity)
        {
            return _orderDAO.UpdateAsync(entity);
        }

        async Task<Order?> IService<Order>.FindByIdAsync(int Id)
        {
            return await _orderDAO.FindByAsync(Id);
        }
    }
}
