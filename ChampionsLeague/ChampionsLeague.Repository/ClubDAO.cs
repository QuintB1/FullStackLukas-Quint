using ChampionsLeague.Domain.EntitiesDB;
using ChampionsLeague.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChampionsLeague.Repository
{
    public class ClubDAO : IDAO<Club>
    {
        private IDAO<Club> dAO;
        public ClubDAO(IDAO<Club> club)
        {
            dAO = club;
        }

        public Task AddAsync(Club entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Club entity)
        {
            throw new NotImplementedException();
        }

        public Task FindByAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Club>?> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Club entity)
        {
            throw new NotImplementedException();
        }
    }
}
