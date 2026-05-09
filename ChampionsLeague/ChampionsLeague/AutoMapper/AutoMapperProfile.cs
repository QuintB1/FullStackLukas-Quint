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

            CreateMap<Stadium, StadiumVM>()
            .ForMember(dest => dest.Sections,
                opt => opt.MapFrom(src => src.StadiumSections));

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

            // TICKET ASSIGNMENTS
            CreateMap<TicketAssignment, TicketAssignmentVM>()
            .ForMember(dest => dest.SectionName,
                opt => opt.MapFrom(src => src.Seat.Section.Name))
            .ForMember(dest => dest.SeatNumber,
                opt => opt.MapFrom(src => src.Seat.SeatNumber))
            .ForMember(dest => dest.MatchDate,
                opt => opt.MapFrom(src => src.Ticket.Match.DateTime))
            .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Ticket.Product.Name));



            // SUBSCRIPTION ASSIGNMENTS
            CreateMap<SubscriptionAssignment, SubscriptionAssignmentVM>()
            .ForMember(dest => dest.SectionName,
                opt => opt.MapFrom(src => src.Seat.Section.Name))
            .ForMember(dest => dest.SeatNumber,
                opt => opt.MapFrom(src => src.Seat.SeatNumber))
            .ForMember(dest => dest.SeasonStart,
                opt => opt.MapFrom(src => src.Subscription.Season.StartDate))
            .ForMember(dest => dest.SeasonEnd,
                opt => opt.MapFrom(src => src.Subscription.Season.EndDate))
            .ForMember(dest => dest.ProductName,
    opt => opt.MapFrom(src => src.Subscription.Product.Name));


        }








    }
}
