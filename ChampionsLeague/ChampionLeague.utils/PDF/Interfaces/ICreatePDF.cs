using ChampionsLeague.Domain.EntitiesDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChampionLeague.utils.PDF.Interfaces
{
    public interface ICreatePDF
    {
        byte[] CreatePDFDocument(List<Ticket> tickets, List<Subscription> subscriptions);
    }
}
