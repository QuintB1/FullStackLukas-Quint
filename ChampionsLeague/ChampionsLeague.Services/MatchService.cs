using ChampionsLeague.Domain.Data;
using ChampionsLeague.Domain.Entities;
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
    public class MatchService : IService<Match>
    {
        private readonly IDAO<Match> _matchDAO;
        public MatchService(IDAO<Match> context)
        {
            _matchDAO = context;
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
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Match>> GetAllAsync()
        {
            return await _matchDAO.GetAllAsync();
        }

        public Task UpdateAsync(Match entity)
        {
            throw new NotImplementedException();
        }
    }
}
