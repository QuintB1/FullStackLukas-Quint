using ChampionsLeague.Repository.Interfaces;
using ChampionsLeague.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChampionsLeague.Services
{
    public class SubscriptionService : ISubscriptionService
    {
        private readonly ISubscriptionDAO _subscriptionDAO;
        public SubscriptionService(ISubscriptionDAO subscriptionDAO)
        {
            _subscriptionDAO = subscriptionDAO;
        }
        public Task AsssignSubscriptionAsync(int SubscriptionId, string UserId)
        {
            throw new NotImplementedException();
        }
    }
}
