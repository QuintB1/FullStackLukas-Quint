using ChampionsLeague.Domain.DataDB;
using ChampionsLeague.Domain.EntitiesDB;
using ChampionsLeague.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ChampionsLeague.Repository.DAO
{
    public class ClubDAO : IClubDAO
    {
        private readonly ChampionLeagueDbContext _context;

        public ClubDAO(ChampionLeagueDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Club>?> GetAllAsync()
        {
            return await _context.Clubs.ToListAsync();
        }

        public async Task<Club?> FindByAsync(int id)
        {
            return await _context.Clubs.FirstOrDefaultAsync(c => c.ClubId == id);
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

        public async Task<IEnumerable<Club>?> GetAllWithHomeStadium()
        {
            return await _context.Clubs.Where(c => c.HomeStadiumId != null).ToListAsync();
        }

        public async Task<IEnumerable<Club>?> GetAllWithMatches()
        {
            return await _context.Clubs.Where(c => c.MatchAwayClubNavigations.Any() || c.MatchHomeClubNavigations.Any()).ToListAsync();
        }
    }
}
