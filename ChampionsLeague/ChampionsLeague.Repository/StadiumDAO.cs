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
        private readonly IDAO<Stadium> _dAO;
        private readonly ChampionsLeagueDbContext _context;

        public StadiumDAO(IDAO<Stadium> stadium, ChampionsLeagueDbContext context) {
            _dAO = stadium;
            _context = context;
           }

        public Task AddAsync(Stadium entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Stadium entity)
        {
            throw new NotImplementedException();
        }

        public Task FindByAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Stadium>?> GetAllAsync()
        {
            return await _context.Stadia.ToListAsync();
        }

        public Task UpdateAsync(Stadium entity)
        {
            throw new NotImplementedException();
        }
    }
}
