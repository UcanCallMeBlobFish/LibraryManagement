using Application.DTOs;
using AutoMapper;
using Domain.Models;

namespace Application.Mapper
{
    public class CheckoutMappingProfile : Profile
    {
        public CheckoutMappingProfile()
        {
            CreateMap<Checkout, CheckoutDto>();

            CreateMap<CheckoutCreateDto, Checkout>();
            CreateMap<CheckoutUpdateDto, Checkout>();
            CreateMap<CheckoutDeleteDto, Checkout>();
        }
    }
}
