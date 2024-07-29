using Application.DTOs;
using AutoMapper;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mapper
{
    public class EditorMappingProfile : Profile
    {
        public EditorMappingProfile()
        {
            CreateMap<Editor, EditorDto>()
                .ForMember(dest => dest.BookOnShelvesIds, opt => opt.MapFrom(src => src.bookOnShelves.Select(b => b.Id)));

            CreateMap<EditorCreateDto, Editor>();
            CreateMap<EditorUpdateDto, Editor>();
            CreateMap<EditorDeleteDto, Editor>();
        }
    }
}
