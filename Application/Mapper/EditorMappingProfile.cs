using Application.DTOs;
using AutoMapper;
using Domain.Models;
using System.Linq;

namespace Application.Mapper
{
    public class EditorMappingProfile : Profile
    {
        public EditorMappingProfile()
        {
            CreateMap<Editor, EditorDto>()
                .ForMember(dest => dest.BookOnShelvesIds, opt => opt.MapFrom(src => src.bookOnShelves.Select(b => b.Id)))
                .ReverseMap();

            CreateMap<EditorCreateDto, Editor>().ReverseMap();
            CreateMap<EditorUpdateDto, Editor>().ReverseMap();
            CreateMap<EditorDeleteDto, Editor>().ReverseMap();
        }
    }
}
