using ChampionsLeague.Domain.DataDB;
using ChampionsLeague.Repository.Interfaces;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChampionsLeague.Repository
{
    public class TicketDAO : IticketDAO
    {
        private readonly ChampionLeagueDbContext _context;
        public TicketDAO(ChampionLeagueDbContext context)
        {
            _context = context;
        }
        public Task AsssignTicketAsync(int ticketId, string userId)
        {
            throw new NotImplementedException();
        }
    }
}
