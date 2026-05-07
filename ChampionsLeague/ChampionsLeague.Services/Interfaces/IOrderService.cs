using ChampionsLeague.Domain.EntitiesDB;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChampionsLeague.Services.Interfaces
{
    public interface IOrderService: IService<Order>
    {
        Task<Order?> GetUserShoppingCart(String id);
        Task AddTicketToCart(int productId, string userId);
        Task AddSubscriptionToCart(int productId, string userId);
        Task RemoveFromCart(int lineId, String userId);
        Task<List<StadiumSection>> GetSectionsForProduct(int productId);
        Task UpdateCart(Order order, string userId);
        Task SendOrderConfirmationAsync(Order order);
        Task Checkout(int orderId);
        Task CancelSubscription(int assignmentId);
        Task CancelTicket(int assignmentId);
        Task<List<Order>> GetHistory(string userId);
        Task<List<TicketAssignment>> GetValidTicketAssignments(String userId);
        Task<List<SubscriptionAssignment>> GetValidSubscriptionAssignments(String userId);

    }
}
