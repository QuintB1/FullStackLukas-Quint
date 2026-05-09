using ChampionsLeague.Domain.EntitiesDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChampionsLeague.Repository.Interfaces
{
    public interface IMatchDAO: IDAO<Match>
    {
        Task<IEnumerable<Match>?> GetAllMatchesWithClubIdAsync(int id);
        Task<IEnumerable<Stadium>?> GetAllStadiums();
    }
}
