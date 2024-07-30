using Application.DTOs;
using AutoMapper;
using Domain.Models;

namespace Application.Mapper
{
    public class BookOnShelvesMappingProfile : Profile
    {
        public BookOnShelvesMappingProfile()
        {
            CreateMap<BookOnShelves, BookOnShelvesDto>()
                .ForMember(dest => dest.CheckoutIds, opt => opt.MapFrom(src => src.Checkouts.Select(c => c.Id)))
                .ReverseMap();

            CreateMap<BookOnShelvesCreateDto, BookOnShelves>().ReverseMap();
            CreateMap<BookOnShelvesUpdateDto, BookOnShelves>().ReverseMap();
            CreateMap<BookOnShelvesDeleteDto, BookOnShelves>().ReverseMap();
        }
    }
}
