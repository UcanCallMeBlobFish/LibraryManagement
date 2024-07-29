using Application.DTOs;
using AutoMapper;
using Domain.Models;

namespace Application.Mapper
{
    public class BookMappingProfile : Profile
    {
        public BookMappingProfile()
        {
            CreateMap<Book, BookDto>()
                .ForMember(dest => dest.BookAuthorIds, opt => opt.MapFrom(src => src.bookAuthors.Select(ba => ba.Id)))
                .ForMember(dest => dest.BookOnShelvesIds, opt => opt.MapFrom(src => src.bookOnShelves.Select(bs => bs.Id)));

            CreateMap<BookCreateDto, Book>();
            CreateMap<BookUpdateDto, Book>();
            CreateMap<BookDeleteDto, Book>();
        }
    }
}
