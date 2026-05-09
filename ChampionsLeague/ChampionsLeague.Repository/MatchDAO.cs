using ChampionsLeague.Domain.DataDB;
using ChampionsLeague.Domain.EntitiesDB;
using ChampionsLeague.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChampionsLeague.Repository
{
    public class MatchDAO : IMatchDAO
    {
        private readonly ChampionLeagueDbContext _context;

        public MatchDAO(ChampionLeagueDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Match>?> GetAllAsync()
        {
            return await _context.Matches
            .Include(m => m.HomeClubNavigation)
            .Include(m => m.AwayClubNavigation)
            .Include(m => m.Stadium)
            .Include(m => m.Tickets)
            .ToListAsync();
        }


        public async Task UpdateAsync(Match entity)
        {
            _context.Matches.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<Match?> FindByAsync(int id)
        {
            return await _context.Matches.FindAsync(id);
        }

        public async Task<IEnumerable<Match>?> GetAllMatchesWithClubIdAsync(int id)
        {
            var now = DateTime.UtcNow;

            return await _context.Matches
                .Include(m => m.HomeClubNavigation)
                .Include(m => m.AwayClubNavigation)
                .Include(m => m.Stadium)
                .Where(m =>
                    m.DateTime > now &&
                    (m.HomeClub == id || m.AwayClub == id))
                .ToListAsync();
        }

        public async Task<IEnumerable<Stadium>?> GetAllStadiums()
        {
            return await _context.Stadia
                .Include(s => s.StadiumSections)
                .ToListAsync();
        }

        public async Task<IEnumerable<Match>?> GetAllMatchesWithClubIdAsync(int homeclubId, int awayClubId)
        {
            return await _context.Matches
                .Include (m => m.HomeClubNavigation)
                .Include (m => m.AwayClubNavigation)
                .Include(m => m.Stadium)
                .Where(m => m.HomeClub == homeclubId && m.AwayClub == awayClubId).ToListAsync(); 
        }
    }
}