using ChampionsLeague.Domain.EntitiesDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChampionsLeague.Services.Interfaces
{
    public interface IOrderService: IService<Order>
    {
        Task<Order?> GetUserShoppingCart(String id);
        Task UpdatePriceAsync(String id);
        Task AddTicketToCart(int productId, string userId);
        Task AddSubscriptionToCart(int productId, string userId);
        Task RemoveFromCart(int lineId, String userId);
        Task<List<StadiumSection>> GetSectionsForProduct(int productId);

    }
}
