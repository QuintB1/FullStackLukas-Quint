using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChampionsLeague.Services.Interfaces
{
    public interface ITicketService
    {
        Task AsssignTicketAsync(int ticketId,String userId);s
    }
}
}
