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
        private IDAO<Order> _orderDAO;
        public OrderDAO(IDAO<Order> dAO) {
            _orderDAO = dAO;
        }

        public Task AddAsync(Order entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Order entity)
        {
            throw new NotImplementedException();
        }

        public Task FindByAsync(int UserId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Order>?> GetAllAsync()
        {
            return _orderDAO.GetAllAsync();
        }

        public Task UpdateAsync(Order entity)
        {
            throw new NotImplementedException();
        }
    }
}
