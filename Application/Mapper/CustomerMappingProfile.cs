using Application.DTOs;
using AutoMapper;
using Domain.Models;

namespace Application.Mapper
{
    public class CustomerMappingProfile : Profile
    {
        public CustomerMappingProfile()
        {
            CreateMap<Customer, CustomerDto>()
                .ForMember(dest => dest.CheckoutIds, opt => opt.MapFrom(src => src.Checkouts.Select(c => c.Id)))
                .ForMember(dest => dest.AlertIds, opt => opt.MapFrom(src => src.Alerts.Select(a => a.Id)));

            CreateMap<CustomerCreateDto, Customer>();
            CreateMap<CustomerUpdateDto, Customer>();
            CreateMap<CustomerDeleteDto, Customer>();
        }
    }
}
