using ChampionsLeague.Domain.EntitiesDB;
using ChampionsLeague.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChampionsLeague.Services
{
    public class ClubService : IService<Club>
    {
        public Task AddAsync(Club entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Club entity)
        {
            throw new NotImplementedException();
        }

        public Task<Club?> FindByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Club>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Club entity)
        {
            throw new NotImplementedException();
        }
    }
}
