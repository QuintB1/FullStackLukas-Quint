using ChampionsLeague.Domain.Entities;
using ChampionsLeague.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChampionsLeague.Repository
{
    public class OrderLineDAO : IDAO<OrderLine>
    {
            private IDAO<OrderLine> dAO;
        public OrderLineDAO(IDAO<OrderLine> orderLine) {
            dAO = orderLine;
            }
        public Task AddAsync(OrderLine entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(OrderLine entity)
        {
            throw new NotImplementedException();
        }

        public Task FindByAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<OrderLine>?> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(OrderLine entity)
        {
            throw new NotImplementedException();
        }
    }
}
