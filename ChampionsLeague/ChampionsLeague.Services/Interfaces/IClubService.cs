using ChampionsLeague.Domain.EntitiesDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChampionsLeague.Services.Interfaces
{
    public interface IClubService : IService<Club>
    {
        Task<IEnumerable<Club>?> GetAllWithHomeStadium();
        Task<IEnumerable<Club>?> GetAllWithMatches();
    }

}
