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
    public class StadiumDAO : IDAO<Stadium>
    {
        private readonly DbContextChampionsLeague _context;

        public StadiumDAO(DbContextChampionsLeague context) {
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

        public async Task<IEnumerable<Stadium>?> GetAllAsync()
        {
            return await _context.Stadia.ToListAsync();
        }

        public Task UpdateAsync(Stadium entity)
        {
            throw new NotImplementedException();
        }

        Task<Stadium?> IDAO<Stadium>.FindByAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
