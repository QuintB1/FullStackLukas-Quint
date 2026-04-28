using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChampionsLeague.Repository.Interfaces
{
    public interface IticketDAO
    {
        Task AsssignTicketAsync(int ticketId, String userId);
    }
}
