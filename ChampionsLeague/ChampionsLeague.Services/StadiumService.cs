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
    public class StadiumService : IService<Stadium>
    {
        private IDAO<Stadium> StadiumDAO;
        public Task AddAsync(Stadium entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Stadium entity)
        {
            throw new NotImplementedException();
        }

        public Task<Stadium?> FindByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Stadium>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Stadium entity)
        {
            throw new NotImplementedException();
        }
    }
}
