using ChampionsLeague.Domain.DataDB;
using ChampionsLeague.Domain.EntitiesDB;
using ChampionsLeague.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ChampionsLeague.Repository.DAO
{
    public class ClubDAO : IDAO<Club>
    {
        private readonly ChampionLeagueDbContext _context;

        public ClubDAO(ChampionLeagueDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Club>?> GetAllAsync()
        {
            return await _context.Clubs
                .Include(c => c.HomeStadium)
                .Include(c => c.MatchHomeClubNavigations)
                .Include(c => c.MatchAwayClubNavigations)
                .Include(c => c.Subscriptions)
                .ToListAsync();
        }

        public async Task<Club?> FindByAsync(int id)
        {
            return await _context.Clubs
                .Include(c => c.HomeStadium)
                .Include(c => c.MatchHomeClubNavigations)
                .Include(c => c.MatchAwayClubNavigations)
                .Include(c => c.Subscriptions)
                .FirstOrDefaultAsync(c => c.ClubId == id);
        }

        public async Task AddAsync(Club entity)
        {
            _context.Clubs.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Club entity)
        {
            _context.Clubs.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Club entity)
        {
            _context.Clubs.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
