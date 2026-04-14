using ChampionsLeague.Domain.EntitiesDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChampionsLeague.Repository.Interfaces
{
    public interface IClubDAO : IDAO<Club>
    {
        Task<IEnumerable<Club>?> GetAllWithHomeStadium();
        Task<IEnumerable<Club>?> GetAllWithMatches();

    }
}
