using ChampionsLeague.Domain.Entities;
using ChampionsLeague.Repository.Interfaces;

namespace ChampionsLeague.Services
{
    public class StadiumService
    {
        private readonly IDAO<Stadium> _stadiumDao;

        public StadiumService(IDAO<Stadium> stadiumDao)
        {
            _stadiumDao = stadiumDao;
        }

        public async Task<IEnumerable<Stadium>?> GetAllStadiumsAsync()
        {
            return await _stadiumDao.GetAllAsync();
        }

        public async Task<Stadium?> GetStadiumByIdAsync(int id)
        {
            return await _stadiumDao.FindByAsync(id);
        }

        public async Task AddStadiumAsync(Stadium stadium)
        {
            // Business rules could go here:
            // - Validate capacity
            // - Ensure stadium name uniqueness
            // - Ensure subscription seat count is valid

            await _stadiumDao.AddAsync(stadium);
        }

        public async Task UpdateStadiumAsync(Stadium stadium)
        {
            await _stadiumDao.UpdateAsync(stadium);
        }

        public async Task DeleteStadiumAsync(int id)
        {
            var stadium = await _stadiumDao.FindByAsync(id);

            if (stadium == null)
                throw new KeyNotFoundException($"Stadium with ID {id} not found.");

            await _stadiumDao.DeleteAsync(stadium);
        }
    }
}
