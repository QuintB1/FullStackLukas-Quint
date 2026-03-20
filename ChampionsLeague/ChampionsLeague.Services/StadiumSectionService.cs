using ChampionsLeague.Domain.Entities;
using ChampionsLeague.Repository.Interfaces;
using ChampionsLeague.Services.Interfaces;

namespace ChampionsLeague.Services
{
    public class StadiumSectionService : IService<StadiumSection>
    {
        private readonly IDAO<StadiumSection> _stadiumSectionDao;

        public StadiumSectionService(IDAO<StadiumSection> stadiumSectionDao)
        {
            _stadiumSectionDao = stadiumSectionDao;
        }

        public async Task<IEnumerable<StadiumSection>?> GetAllAsync()
        {
            return await _stadiumSectionDao.GetAllAsync();
        }

        public async Task<StadiumSection?> FindByIdAsync(int id)
        {
            return await _stadiumSectionDao.FindByAsync(id);
        }

        public async Task AddAsync(StadiumSection section)
        {
            // Future business rules could go here:
            // - Validate capacity > 0
            // - Ensure section name is unique within the stadium
            // - Ensure stadium exists before adding a section

            await _stadiumSectionDao.AddAsync(section);
        }

        public async Task UpdateAsync(StadiumSection section)
        {
            await _stadiumSectionDao.UpdateAsync(section);
        }

        public async Task DeleteAsync(int id)
        {
            var section = await _stadiumSectionDao.FindByAsync(id);

            if (section == null)
                throw new KeyNotFoundException($"Stadium section with ID {id} not found.");

            await _stadiumSectionDao.DeleteAsync(section);
        }

        public Task DeleteAsync(StadiumSection entity)
        {
            throw new NotImplementedException();
        }
    }
}
