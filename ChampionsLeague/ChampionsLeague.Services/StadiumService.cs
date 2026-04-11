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

        public async Task AddAsync(Stadium entity)
        {
            await _stadiumDAO.AddAsync(entity);
        }

        public async Task DeleteAsync(Stadium entity)
        {
            await _stadiumDAO.DeleteAsync(entity);
        }

        public async Task<Stadium?> FindByIdAsync(int Id)
        {
            return await _stadiumDAO.FindByAsync(Id);
        }

        public async Task<IEnumerable<Stadium>> GetAllAsync()
        {
            return await _stadiumDAO.GetAllAsync();
        }

        public async Task UpdateAsync(Stadium entity)
        {
            await _stadiumDAO.UpdateAsync(entity);
        }
    }
}
