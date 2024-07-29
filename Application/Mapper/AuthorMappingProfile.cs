using Application.DTOs;
using AutoMapper;
using Domain.Models;

namespace Application.Mapper
{
    public class AuthorMappingProfile : Profile
    {
        public AuthorMappingProfile()
        {
            CreateMap<Author, AuthorDto>()
                .ForMember(dest => dest.BookAuthorIds, opt => opt.MapFrom(src => src.bookAuthors.Select(ba => ba.Id)));

            CreateMap<AuthorCreateDto, Author>();
            CreateMap<AuthorUpdateDto, Author>();
            CreateMap<AuthorDeleteDto, Author>();
        }
    }
}
