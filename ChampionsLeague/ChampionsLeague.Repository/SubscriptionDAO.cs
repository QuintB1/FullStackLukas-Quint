using ChampionsLeague.Domain.DataDB;
using ChampionsLeague.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChampionsLeague.Repository
{
    public class SubscriptionDAO : ISubscriptionDAO
    {
        private readonly ChampionLeagueDbContext _context;
        public SubscriptionDAO(ChampionLeagueDbContext context)
        {
            _context = context;
        }

        public Task AsssignSubscriptionAsync(int SubscriptionId, string userId)
        {
            throw new NotImplementedException();
        }
    }
}
