using ChampionsLeague.Domain.Data;
using ChampionsLeague.Domain.Entities;
using ChampionsLeague.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChampionsLeague.Repository
{
    public class MatchDAO : IDAO<Match>
    {
        private readonly DbContextChampionsLeague _context;

        public MatchDAO(DbContextChampionsLeague context)
        {
            _context = context;
        }
        public Task AddAsync(Match entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Match entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Match>?> GetAllAsync()
        {
            return await _context.Matches.ToListAsync();
        }


        public Task UpdateAsync(Match entity)
        {
            throw new NotImplementedException();
        }

        Task<Match?> IDAO<Match>.FindByAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
