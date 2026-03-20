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
    public class MatchDAO : IDAO<Match>
    {
        private readonly IDAO<Match> _matchDAO;
        private readonly ChampionsLeagueDbContext _context;

        public MatchDAO(IDAO<Match> dAO, ChampionsLeagueDbContext context)
        {
            _matchDAO = dAO;
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

        public Task FindByAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Match>?> GetAllAsync()
        {
            return _matchDAO.GetAllAsync();
        }

        public Task UpdateAsync(Match entity)
        {
            throw new NotImplementedException();
        }
    }
}
