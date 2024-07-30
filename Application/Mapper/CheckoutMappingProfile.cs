using Application.DTOs;
using AutoMapper;
using Domain.Models;

namespace Application.Mapper
{
    public class CheckoutMappingProfile : Profile
    {
        public CheckoutMappingProfile()
        {
            CreateMap<Checkout, CheckoutDto>().ReverseMap();
            CreateMap<CheckoutCreateDto, Checkout>().ReverseMap();
            CreateMap<CheckoutUpdateDto, Checkout>().ReverseMap();
            CreateMap<CheckoutDeleteDto, Checkout>().ReverseMap();
        }
    }
}
