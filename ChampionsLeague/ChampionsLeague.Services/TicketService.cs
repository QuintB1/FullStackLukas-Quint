using ChampionsLeague.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChampionsLeague.Services
{
    public class TicketService : ITicketService
    {
        private readonly ITicketService _ticketService;
        public TicketService(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }
        public Task AsssignTicketAsync(int ticketId, string userId)
        {
            throw new NotImplementedException();
        }
    }
}
