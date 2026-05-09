using AutoMapper;
using ChampionLeague.utils.Mail.Interfaces;
using ChampionLeague.utils.PDF.Interfaces;
using ChampionsLeague.Domain.EntitiesDB;
using ChampionsLeague.Services.Interfaces;
using ChampionsLeague.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Tasks;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using Newtonsoft.Json;
using NuGet.Protocol.Plugins;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ChampionsLeague.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IOrderService _order;
        private readonly IMapper _mapper;
        private readonly IEmailSend _email;
        private readonly ICreatePDF _pdf;

        public ShoppingCartController(IOrderService order, IMapper mapper, IEmailSend email, ICreatePDF pdf)
        {
            _order = order;
            _mapper = mapper;
            _email = email;
            _pdf = pdf;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var cartData = await _order.GetUserShoppingCart(userId);

            if (cartData == null)
                return View(null);

            var vm = _mapper.Map<OrderVM>(cartData);
            return View(vm);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CheckOut(string cartJson)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(cartJson))
                {
                    return BadRequest("Cart JSON was not received.");
                }

                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                var vm = JsonConvert.DeserializeObject<OrderVM>(cartJson);

                var order = _mapper.Map<Order>(vm);

                await _order.UpdateCart(order, userId);
                await _order.Checkout(order.OrderId);

                var assignments = await _order.GetOrderTicketAssignments(order.OrderId, userId);

                List<Ticket> tickets = new List<Ticket>();

                foreach (var assignment in assignments)
                {
                    tickets.Add(assignment.Ticket);
                }

                var pdfFiles = _pdf.CreatePDFDocument(tickets);

                

                var email = User.FindFirstValue(ClaimTypes.Email);

                await _email.SendEmailAttachmentAsync(
                    email, 
                    "Your Champions League Tickets", 
                    "<h1>Thank you for your purchase</h1><p>Your tickets are attached.</p>", 
                    pdfFiles
                );

                return View("Success");
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
                
        }

        [Authorize]
        public async Task<IActionResult> RemoveFromCart(int lineId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            await _order.RemoveFromCart(lineId, userId);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> GetSectionsForProduct(int productId)
        {
            var sections = await _order.GetSectionsForProduct(productId);

            if (sections == null || sections.Count < 1)
                return NotFound("No sections found");

            var vm = _mapper.Map<List<StadiumSectionVM>>(sections);

            return Json(vm);
        }
        [HttpGet]
        public async Task<IActionResult> GetTicketAssignments()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var assignments = await _order.GetValidTicketAssignments(userId);

            var vm = _mapper.Map<List<TicketAssignmentVM>>(assignments);
            return Json(vm);
        }


        [HttpGet]
        public async Task<IActionResult> GetSubscriptionAssignments()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var assignments = await _order.GetValidSubscriptionAssignments(userId);

            var vm = _mapper.Map<List<SubscriptionAssignmentVM>>(assignments);
            return Json(vm);
        }





        [Authorize]
        public async Task<IActionResult> History(string email)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var cartData = await _order.GetHistory(userId);

            if (cartData == null)
                return View(null);

            var vm = _mapper.Map<List<OrderVM>>(cartData);
            return View(vm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CancelProduct(int assignmentId, String productType)
        {
            try
            {
                if (productType.Equals("Ticket"))
                {
                    await _order.CancelTicket(assignmentId);
                }
                else
                {
                    await _order.CancelSubscription(assignmentId);
                }
                return RedirectToAction("History");
            }
            catch (Exception ex)
            {
                if (ex.InnerException == null)
                {
                    return BadRequest(ex.Message);
                }
                else
                {
                    return BadRequest(ex.InnerException.Message);
                }
            }
        }

    }
}
