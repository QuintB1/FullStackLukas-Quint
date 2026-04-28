using ChampionsLeague.Repository.Interfaces;
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
        private readonly IticketDAO _Ticketdao;
        public TicketService(IticketDAO dao)
        {
            _Ticketdao = dao;
        }
        public Task AsssignTicketAsync(int ticketId, string userId)
        {
            throw new NotImplementedException();
        }
    }
}
