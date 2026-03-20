using AutoMapper;
using ChampionsLeague.Domain.Entities;
using ChampionsLeague.ViewModels;

namespace BeerschopNET9_Identity.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {


            CreateMap<Stadium, StadiumVM>();






        }
    }
}
