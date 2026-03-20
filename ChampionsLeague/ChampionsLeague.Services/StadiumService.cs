using ChampionsLeague.Domain.EntitiesDB;
using ChampionsLeague.Repository;
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
        private IDAO<Stadium> _stadiumDAO;

        public StadiumService(IDAO<Stadium> stadiumDAO)
        {
            _stadiumDAO = stadiumDAO;
        }

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

        public async Task<IEnumerable<Stadium>> GetAllAsync()
        {
            return await _stadiumDAO.GetAllAsync();
        }

        public Task UpdateAsync(Stadium entity)
        {
            throw new NotImplementedException();
        }
    }
}
