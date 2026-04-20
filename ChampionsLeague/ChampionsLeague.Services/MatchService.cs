using ChampionsLeague.Domain.EntitiesDB;
using ChampionsLeague.Repository;
using ChampionsLeague.Repository.Interfaces;
using ChampionsLeague.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChampionsLeague.Services
{
    public class MatchService : IMatchService
    {
        private readonly MatchDAO _matchDao;

        public MatchService(MatchDAO matchDao)
        {
            _matchDao = matchDao;
        }


        public Task AddAsync(Match entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Match entity)
        {
            throw new NotImplementedException();
        }

        public async Task<Match?> FindByIdAsync(int Id)
        {
            return await _matchDao.FindByAsync(Id);
        }

        public async Task<IEnumerable<Match>> GetAllAsync()
        {
            return await _matchDao.GetAllAsync();
        }

        public Task UpdateAsync(Match entity)
        {
            throw new NotImplementedException();
        }
        public async Task<IEnumerable<Match>> GetTop10UpcomingMatchesAsync()
        {
            var now = DateTime.UtcNow;

            var matches = await _matchDao.GetAllAsync();

            if (matches == null)
            {
                return Enumerable.Empty<Match>();
            }
                return matches;

            
        }

        Task<Match?> IService<Match>.FindByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Match>?> GetAllByClubID(int club)
        {
            return _matchDao.GetAllMatchesWithClubIdAsync(club);
        }
    }
}
