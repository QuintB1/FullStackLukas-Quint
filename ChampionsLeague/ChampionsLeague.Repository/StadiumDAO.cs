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
    public class StadiumDAO : IDAO<Stadium>
    {
        private readonly ChampionLeagueDbContext _context;

        public StadiumDAO(ChampionLeagueDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Stadium entity)
        {
            _context.Stadia.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Stadium entity)
        {
            _context.Stadia.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Stadium>?> GetAllAsync()
        {
            return await _context.Stadia.ToListAsync();
        }

        public async Task UpdateAsync(Stadium entity)
        {
            _context.Stadia.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<Stadium?> FindByAsync(int id)
        {
            return await _context.Stadia
                .Include(s => s.StadiumSections)
                .FirstOrDefaultAsync(s => s.StadiumId == id);
        }


        public async Task<Stadium?> FetchStadiumByClubId(int clubId)
        {
            return await _context.Stadia
                .Include(s => s.StadiumSections)
                .Include(s => s.Clubs)
                .FirstOrDefaultAsync(s => s.Clubs.Any(c => c.ClubId == clubId));
        }

    }
}
