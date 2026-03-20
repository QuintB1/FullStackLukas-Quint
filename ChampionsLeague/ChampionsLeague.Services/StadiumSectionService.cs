using ChampionsLeague.Domain.Entities;
using ChampionsLeague.Repository.Interfaces;

namespace ChampionsLeague.Services
{
    public class StadiumSectionService
    {
        private readonly IDAO<StadiumSection> _stadiumSectionDao;

        public StadiumSectionService(IDAO<StadiumSection> stadiumSectionDao)
        {
            _stadiumSectionDao = stadiumSectionDao;
        }

        public async Task<IEnumerable<StadiumSection>?> GetAllSectionsAsync()
        {
            return await _stadiumSectionDao.GetAllAsync();
        }

        public async Task<StadiumSection?> GetSectionByIdAsync(int id)
        {
            return await _stadiumSectionDao.FindByAsync(id);
        }

        public async Task AddSectionAsync(StadiumSection section)
        {
            // Future business rules could go here:
            // - Validate capacity > 0
            // - Ensure section name is unique within the stadium
            // - Ensure stadium exists before adding a section

            await _stadiumSectionDao.AddAsync(section);
        }

        public async Task UpdateSectionAsync(StadiumSection section)
        {
            await _stadiumSectionDao.UpdateAsync(section);
        }

        public async Task DeleteSectionAsync(int id)
        {
            var section = await _stadiumSectionDao.FindByAsync(id);

            if (section == null)
                throw new KeyNotFoundException($"Stadium section with ID {id} not found.");

            await _stadiumSectionDao.DeleteAsync(section);
        }
    }
}
