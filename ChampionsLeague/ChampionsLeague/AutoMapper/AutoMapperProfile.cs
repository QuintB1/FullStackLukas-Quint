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
            CreateMap<Match, MatchVM>().ForMember(dest => dest.HomeClubName, opts => opts.MapFrom(
                src => src.HomeClubNavigation.Name))

                .ForMember(dest => dest.AwayClubName, opts => opts.MapFrom(
                src => src.AwayClubNavigation.Name));

            CreateMap<Stadium, StadiumVM>()
    .ForMember(dest => dest.Sections, opt => opt.MapFrom(src => src.StadiumSections));

            CreateMap<StadiumSection, StadiumSectionVM>();







        }
    }
}
