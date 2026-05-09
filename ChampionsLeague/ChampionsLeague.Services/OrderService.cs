using ChampionLeague.utils.Mail.Interfaces;
using ChampionLeague.utils.PDF.Interfaces;
using ChampionsLeague.Domain.DataDB;
using ChampionsLeague.Domain.EntitiesDB;
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
    public class OrderService : IOrderService
    {
        private readonly IOrderDAO _orderDAO;
        private readonly ICreatePDF _createPDF;
        private readonly IEmailSend _emailSend;
        private readonly ChampionLeagueDbContext _context;

        public OrderService(IOrderDAO DAO, ICreatePDF createPDF, IEmailSend emailSend, ChampionLeagueDbContext context)
        {
            _orderDAO = DAO;
            _createPDF = createPDF;
            _emailSend = emailSend;
            _context = context;
        }

        public async Task AddSubscriptionToCart(int clubId, string userId)
        {
            try
            {
                await _orderDAO.AddSubscriptionToCart(clubId, userId);
            }
            catch (Exception)
            {
                throw;
            }

        }


        public async Task AddTicketToCart(int matchId, string userId)
        {
            try
            {
                await _orderDAO.AddTicketToCart(matchId, userId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<Order?> FindByIdAsync(int Id)
        {
            return _orderDAO.FindByAsync(Id);
        }

        public async Task<IEnumerable<Order>?> GetAllAsync()
        {
            return await _orderDAO.GetAllAsync();
        }

        public Task<Order?> GetUserShoppingCart(string id)
        {
            return _orderDAO.GetUserShoppingCart(id);
        }

        public async Task RemoveFromCart(int lineId,String userId)
        {
            await _orderDAO.RemoveFromCart(lineId, userId);
        }

        public Task UpdateAsync(Order entity)
        {
            return _orderDAO.UpdateAsync(entity);
        }

        async Task<Order?> IService<Order>.FindByIdAsync(int Id)
        {
            return await _orderDAO.FindByAsync(Id);
        }
        public async Task<List<StadiumSection>> GetSectionsForProduct(int productId)
        {
            return await _orderDAO.GetSectionsForProduct(productId);
        }
        public async Task UpdateCart(Order order, string userId)
        {
            await _orderDAO.UpdateCart(order, userId);
        }



        public Task SendOrderConfirmationAsync(string email)
        {
            throw new NotImplementedException();
        }

        //public async Task SendOrderConfirmationAsync(Order order)
        //{
        //    var pdfFiles = new List<byte[]>();

        //    var tickets = _context.TicketAssignments
        //        .Where(ta => ta.UserId == order.UserId && ta.Active && order.Status == "Cart")
        //        .Select(ta => ta.Ticket)
        //        .ToList();

        //    foreach (var line in order.OrderLines)
        //    {
        //        var pdf = _createPDF.CreatePDFDocument(tickets);
        //        pdfFiles.Add(pdf);
        //    }

        //    if (!string.IsNullOrWhiteSpace(order.User.Email))
        //    {
        //        await _emailSend.SendEmailAttachmentAsync(
        //            order.User.Email,
        //            "Orderbevestiging",
        //            "bedankt voor jouw bestelling",
        //            pdfFiles);
        //    }
        //}

        public async Task Checkout(int orderId)
        {
            await _orderDAO.Checkout(orderId);
        }

        public async Task CancelSubscription(int assignmentId)
        {
            await _orderDAO.CancelSubscription(assignmentId);
            return;
        }

        public async Task CancelTicket(int assignmentId)
        {
             await _orderDAO.CancelTicket(assignmentId);
            return;
        }

        public async Task<List<Order>> GetHistory(string userId)
        {
            return await _orderDAO.GetHistory(userId);
        }

        public async Task<List<TicketAssignment>> GetValidTicketAssignments(string userId)
        {
            return await _orderDAO.GetValidTicketAssignments(userId);
        }

        public async Task<List<SubscriptionAssignment>> GetValidSubscriptionAssignments(string userId)
        {
            return await _orderDAO.GetValidSubscriptionAssignments(userId);
        }

        public async Task<List<TicketAssignment>> GetOrderTicketAssignments(int orderId, string userId)
        {
            return await _orderDAO.GetOrderTicketAssignments(orderId, userId);
        }

        public async Task<Stadium?> GetStadiumById(int id)
        {
            return await _orderDAO.GetStadiumById(id);
        }
    }
}
