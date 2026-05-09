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
        Task<Stadium?> GetStadiumById(int id);
        Task AddSubscriptionToCart(int MatchId, String userId);
        Task AddTicketToCart(int MatchId, String userId);
        Task RemoveFromCart(int lineId, String userId);
        Task<List<StadiumSection>> GetSectionsForProduct(int productId);
        Task UpdateCart(Order order, string userId);
        Task Checkout(int orderId);
        Task CancelSubscription(int assignmentId);
        Task CancelTicket(int assignmentId);
        Task<List<Order>> GetHistory(String userId);
        Task<List<TicketAssignment>> GetValidTicketAssignments(String userId);
        Task<List<SubscriptionAssignment>> GetValidSubscriptionAssignments(String userId);

        Task<List<TicketAssignment>> GetOrderTicketAssignments(int orderId, string userId);
    }
}
