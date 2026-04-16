using ChampionsLeague.Domain.EntitiesDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChampionsLeague.Repository.Interfaces
{
    public interface IOrderDAO: IDAO<Order>
    {
        Task<Order?> GetUserShoppingCart(String id);
    }
}
