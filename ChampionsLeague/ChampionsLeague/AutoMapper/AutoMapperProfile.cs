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
            CreateMap<Club, HomeclubStadiumSelectVM>();
            CreateMap<Match, MatchVM>()
    .ForMember(dest => dest.HomeClubName,
        opt => opt.MapFrom(src => src.HomeClubNavigation.Name))
    .ForMember(dest => dest.AwayClubName,
        opt => opt.MapFrom(src => src.AwayClubNavigation.Name))
    .ForMember(dest => dest.StadiumName,
        opt => opt.MapFrom(src => src.Stadium.Name))
    .ForMember(dest => dest.Name,
        opt => opt.MapFrom(src =>
            src.HomeClubNavigation.Name + " vs " + src.AwayClubNavigation.Name))
    .ForMember(dest => dest.StadiumName,
    opt => opt.MapFrom(src => src.Stadium.Name));



            CreateMap<StadiumSection, StadiumSectionVM>();
            CreateMap<Order, OrderVM>()
                .ForMember(dest => dest.OrderLines, opt => opt.MapFrom(src => src.OrderLines));
            CreateMap<OrderLine, OrderLineVM>();
            CreateMap<Product, ProductVM>();

            CreateMap<OrderLine, OrderLineVM>()
                .ForMember(dest => dest.productVM,
                           opt => opt.MapFrom(src => src.Product));

            CreateMap<OrderVM, Order>()
            .ForMember(dest => dest.OrderId, opt => opt.MapFrom(src => src.OrderId))
            .ForMember(dest => dest.OrderDate, opt => opt.MapFrom(src => src.OrderDate))
            .ForMember(dest => dest.OrderLines, opt => opt.MapFrom(src => src.OrderLines));

            CreateMap<OrderLineVM, OrderLine>()
            .ForMember(dest => dest.LineId, opt => opt.MapFrom(src => src.LineId))
            .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
            .ForMember(dest => dest.StadiumSectionId, opt => opt.MapFrom(src => src.StadiumSectionId))
            .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.productVM.ProductId));
        }








    }
}
