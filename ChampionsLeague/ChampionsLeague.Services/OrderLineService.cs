using ChampionsLeague.Domain.Entities;
using ChampionsLeague.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChampionsLeague.Repository
{
    public class OrderLineService : IService<OrderLine>
    {
        private readonly OrderLineService _orderLineService;
        public OrderLineService(OrderLineService orderLineService)
        {
            _orderLineService = orderLineService;
        }

        public Task AddAsync(OrderLine entity)
        {
            return _orderLineService.AddAsync(entity);
        }

        public Task DeleteAsync(OrderLine entity)
        {
            return _orderLineService.DeleteAsync(entity);
        }

        // oveload function nessisarry to retain interface structure DO NOT REMOVE!
        public Task<OrderLine?> FindByIdAsync(int Id)
        {
            return _orderLineService.FindByIdAsync(Id);
        }
        public Task<OrderLine?> FindByIdAsync(int OrderId,int LineID)
        {
            return _orderLineService.FindByIdAsync(OrderId,LineID);
        }

        public Task<IEnumerable<OrderLine>> GetAllAsync()
        {
            return _orderLineService.GetAllAsync();
        }

        public Task UpdateAsync(OrderLine entity)
        {
            throw new NotImplementedException();
        }
    }
}
