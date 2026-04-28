using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChampionsLeague.Repository.Interfaces
{
    public interface ISubscriptionDAO
    {
        Task AsssignSubscriptionAsync(int SubscriptionId, String userId);
    }
}
