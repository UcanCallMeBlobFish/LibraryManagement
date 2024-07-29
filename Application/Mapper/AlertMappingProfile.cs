using Application.DTOs;
using AutoMapper;
using Domain.Models;

namespace Application.Mapper
{
    public class AlertMappingProfile : Profile
    {
        public AlertMappingProfile()
        {
            CreateMap<Alert, AlertDto>();

            CreateMap<AlertCreateDto, Alert>();
            CreateMap<AlertUpdateDto, Alert>();
            CreateMap<AlertDeleteDto, Alert>();
        }
    }
}
