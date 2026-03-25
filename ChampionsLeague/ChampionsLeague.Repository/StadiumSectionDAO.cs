using ChampionsLeague.Domain.Data;
using ChampionsLeague.Domain.Entities;
using ChampionsLeague.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ChampionsLeague.Repository.DAO
{
    public class StadiumSectionDAO : IDAO<StadiumSection>
    {
        private readonly DbContextChampionsLeague _context;

        public StadiumSectionDAO(DbContextChampionsLeague context)
        {
            _context = context;
        }

        public async Task<IEnumerable<StadiumSection>?> GetAllAsync()
        {
            return await _context.StadiumSections
                .Include(ss => ss.Stadium)
                .Include(ss => ss.Seats)
                .ToListAsync();
        }

        public async Task<StadiumSection?> FindByAsync(int id)
        {
            return await _context.StadiumSections
                .Include(ss => ss.Stadium)
                .Include(ss => ss.Seats)
                .FirstOrDefaultAsync(ss => ss.SectionId == id);
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
