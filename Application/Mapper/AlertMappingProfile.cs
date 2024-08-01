using Application.DTOs;
using AutoMapper;
using Domain.Models;

namespace Application.Mapper
{
    public class AlertMappingProfile : Profile
    {
        public AlertMappingProfile()
        {
            CreateMap<Alert, AlertDto>()
              .ForMember(dest => dest.UserTo, opt => opt.MapFrom(src => src.CustomerId))
              .ReverseMap()
              .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(src => src.UserTo));

            CreateMap<Alert, AlertCreateDto>()
                .ForMember(dest => dest.UserTo, opt => opt.MapFrom(src => src.CustomerId))
                .ReverseMap()
                .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(src => src.UserTo));

            CreateMap<Alert, AlertUpdateDto>()
                .ForMember(dest => dest.UserTo, opt => opt.MapFrom(src => src.CustomerId))
                .ReverseMap()
                .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(src => src.UserTo));

            CreateMap<Alert, AlertDeleteDto>()
                .ReverseMap();
        }
    }
}
