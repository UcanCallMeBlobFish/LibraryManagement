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
                .ForMember(dest => dest.AlertIds, opt => opt.MapFrom(src => src.Alerts.Select(a => a.Id)))
                .ReverseMap();

            CreateMap<CustomerCreateDto, Customer>().ReverseMap();
            CreateMap<CustomerUpdateDto, Customer>().ReverseMap();
            CreateMap<CustomerDeleteDto, Customer>().ReverseMap();
        }
    }
}
