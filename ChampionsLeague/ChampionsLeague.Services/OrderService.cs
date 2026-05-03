using ChampionsLeague.Domain.EntitiesDB;
using ChampionsLeague.Repository.Interfaces;
using ChampionsLeague.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
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

        public async Task AddSubscriptionToCart(int clubId, string userId)
        {
            try
            {
                await _orderDAO.AddSubscriptionToCart(clubId, userId);
            }
            catch (Exception)
            {
                throw;
            }

        }


        public async Task AddTicketToCart(int matchId, string userId)
        {
            try
            {
                await _orderDAO.AddTicketToCart(matchId, userId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
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

        public async Task RemoveFromCart(int lineId,String userId)
        {
            await _orderDAO.RemoveFromCart(lineId, userId);
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
        public async Task<List<StadiumSection>> GetSectionsForProduct(int productId)
        {
            return await _orderDAO.GetSectionsForProduct(productId);
        }
        public async Task UpdateCart(Order order, string userId)
        {
            await _orderDAO.UpdateCart(order, userId);
        }



    }

}
