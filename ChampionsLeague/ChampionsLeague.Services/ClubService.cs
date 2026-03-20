using ChampionsLeague.Domain.Entities;
using ChampionsLeague.Repository.Interfaces;

namespace ChampionsLeague.Services
{
    public class ClubService
    {
        private readonly IDAO<Club> _clubDao;

        public ClubService(IDAO<Club> clubDao)
        {
            _clubDao = clubDao;
        }

        public async Task<IEnumerable<Club>?> GetAllClubsAsync()
        {
            return await _clubDao.GetAllAsync();
        }

        public async Task<Club?> GetClubByIdAsync(int id)
        {
            return await _clubDao.FindByAsync(id);
        }

        public async Task AddClubAsync(Club club)
        {
            // Business rules can go here
            // Example: Validate name uniqueness, stadium assignment, etc.

            await _clubDao.AddAsync(club);
        }

        public async Task UpdateClubAsync(Club club)
        {
            await _clubDao.UpdateAsync(club);
        }

        public async Task DeleteClubAsync(int id)
        {
            var club = await _clubDao.FindByAsync(id);

            if (club == null)
                throw new KeyNotFoundException($"Club with ID {id} not found.");

            await _clubDao.DeleteAsync(club);
        }
    }
}
