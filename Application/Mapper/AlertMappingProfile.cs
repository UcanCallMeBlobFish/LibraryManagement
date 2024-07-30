using Application.DTOs;
using AutoMapper;
using Domain.Models;

namespace Application.Mapper
{
    public class AlertMappingProfile : Profile
    {
        public AlertMappingProfile()
        {
            CreateMap<Alert, AlertDto>().ReverseMap();
            CreateMap<Alert, AlertCreateDto>().ReverseMap();
            CreateMap<Alert, AlertUpdateDto>().ReverseMap();
            CreateMap<Alert, AlertDeleteDto>().ReverseMap();
        }
    }
}
