using AutoMapper;
using HttpRequestExamples.Dtos;
using HttpRequestExamples.Models;

namespace HttpRequestExamples.Configuration
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<BtcContent, BtcDto>()
                .ForMember(
                    dest => dest.Price,
                    opt => opt.MapFrom(src => src.Bpi.Eur.Rate));
        }
    }
}