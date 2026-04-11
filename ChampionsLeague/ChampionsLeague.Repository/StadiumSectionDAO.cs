using ChampionsLeague.Domain.DataDB;
using ChampionsLeague.Domain.EntitiesDB;
using ChampionsLeague.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ChampionsLeague.Repository.DAO
{
    public class StadiumSectionDAO : IDAO<StadiumSection>
    {
        private readonly ChampionLeagueDbContext _context;

        public StadiumSectionDAO(ChampionLeagueDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<StadiumSection>?> GetAllAsync()
        {
            return await _context.StadiumSections.ToListAsync();
        }

        public async Task<StadiumSection?> FindByAsync(int id)
        {
            return await _context.StadiumSections.FindAsync(id);
        }

        public async Task AddAsync(StadiumSection entity)
        {
            await _context.StadiumSections.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(StadiumSection entity)
        {
            _context.StadiumSections.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(StadiumSection entity)
        {
            _context.StadiumSections.Remove(entity);
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<StadiumSection>> GetByStadiumIdAsync(int stadiumId)
        {
            return await _context.StadiumSections
                .Where(s => s.StadiumId == stadiumId)
                .ToListAsync();
        }

    }
}
