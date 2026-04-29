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
    public class OrderService : IOrderService
    {
        private readonly IOrderDAO _orderDAO;
    
        public OrderService(IOrderDAO DAO)
        {
            _orderDAO = DAO;
        }
        public Task AddAsync(Order entity)
        {
            return _orderDAO.AddAsync(entity);
        }

        public Task AddSubscriptionToCart(int productId, string userId)
        {
            _orderDAO.AddSubscriptionToCart(productId, userId);
            return Task.CompletedTask;
        }

        public Task AddTicketToCart(int productId, string userId)
        {
            _orderDAO.AddTicketToCart(productId, userId);
            return Task.CompletedTask;
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

        public Task<Order?> GetUserShoppingCart(string id)
        {
            return _orderDAO.GetUserShoppingCart(id);
        }

        public Task UpdateAsync(Order entity)
        {
            return _orderDAO.UpdateAsync(entity);
        }

        public Task UpdatePriceAsync(String id)
        {
            return _orderDAO.UpdatePriceAsync(id);
        }

        async Task<Order?> IService<Order>.FindByIdAsync(int Id)
        {
            return await _orderDAO.FindByAsync(Id);
        }
    }
}
