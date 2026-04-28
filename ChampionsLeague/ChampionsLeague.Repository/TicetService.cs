using ChampionsLeague.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChampionsLeague.Repository
{
    public class TicetService : IticketDAO
    {
        private readonly IticketDAO _ticketDAO;
        public TicetService(IticketDAO ticketDAO)
        {
            _ticketDAO = ticketDAO;
        }
        public Task AsssignTicketAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
