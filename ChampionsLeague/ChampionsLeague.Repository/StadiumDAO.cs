using ChampionsLeague.Domain.Entities;
using ChampionsLeague.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChampionsLeague.Repository
{
    public class StadiumDAO : IDAO<Stadium>
    {
        private IDAO<Stadium> dAO;
        public StadiumDAO(IDAO<Stadium> stadium) {
            dAO = stadium;
           }

        public Task AddAsync(Stadium entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Stadium entity)
        {
            throw new NotImplementedException();
        }

        public Task FindByAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Stadium>?> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Stadium entity)
        {
            throw new NotImplementedException();
        }
    }
}
