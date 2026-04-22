using AutoMapper;
using ChampionsLeague.Domain.EntitiesDB;
using ChampionsLeague.ViewModels;

namespace BeerschopNET9_Identity.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {


            CreateMap<Stadium, StadiumVM>();
            CreateMap<Club, ClubSelectVM>();
            CreateMap<Club,HomeclubStadiumSelectVM>();
            CreateMap<Match, MatchVM>();
            CreateMap<StadiumSection, StadiumSectionVM>();







        }
    }
}
