using ChampionsLeague.Domain.EntitiesDB;
using ChampionsLeague.Repository.Interfaces;
using ChampionsLeague.Services.Interfaces;

namespace ChampionsLeague.Services
{
    public class ClubService : IService<Club> 
    {
        private readonly IDAO<Club> _clubDao;

        public ClubService(IDAO<Club> clubDao)
        {
            _clubDao = clubDao;
        }

        public async Task<IEnumerable<Club>?> GetAllAsync()
        {
            return await _clubDao.GetAllAsync();
        }

        public async Task<Club?> FindByIdAsync(int id)
        {
            return await _clubDao.FindByAsync(id);
        }

        public async Task AddAsync(Club club)
        {
            // Business rules can go here
            // Example: Validate name uniqueness, stadium assignment, etc.

            await _clubDao.AddAsync(club);
        }

        public async Task UpdateAsync(Club club)
        {
            await _clubDao.UpdateAsync(club);
        }

        public async Task DeleteAsync(int id)
        {
            var club = await _clubDao.FindByAsync(id);

            if (club == null)
                throw new KeyNotFoundException($"Club with ID {id} not found.");

            await _clubDao.DeleteAsync(club);
        }

        public async Task DeleteAsync(Club entity)
        {
            await _clubDao.DeleteAsync(entity);
        }
    }
}
