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
                .ForMember(dest => dest.CheckoutIds, opt => opt.MapFrom(src => src.Checkouts.Select(c => c.Id)));

            CreateMap<BookOnShelvesCreateDto, BookOnShelves>();
            CreateMap<BookOnShelvesUpdateDto, BookOnShelves>();
            CreateMap<BookOnShelvesDeleteDto, BookOnShelves>();
        }
    }
}
