using AutoMapper;
using ChampionsLeague.Domain.EntitiesDB;
using ChampionsLeague.ViewModels;

namespace BeerschopNET9_Identity.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {

            CreateMap<Club, ClubSelectVM>();
            CreateMap<Club,HomeclubStadiumSelectVM>();
            CreateMap<Match, MatchVM>();
            CreateMap<Stadium, StadiumVM>()
    .ForMember(dest => dest.Sections, opt => opt.MapFrom(src => src.StadiumSections));

            CreateMap<StadiumSection, StadiumSectionVM>();







        }
    }
}
