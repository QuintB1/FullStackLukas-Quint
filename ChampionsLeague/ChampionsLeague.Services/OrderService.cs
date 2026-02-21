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
        private IDAO<Order> OrderDAO;
    
        public OrderService(IDAO<Order> DAO)
        {
            OrderDAO = DAO;
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
            return await OrderDAO.GetAllAsync();
        }

        public Task UpdateAsync(Order entity)
        {
            throw new NotImplementedException();
        }
    }
}
