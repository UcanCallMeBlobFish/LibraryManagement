using Application.DTOs;
using AutoMapper;
using Domain.Models;

namespace Application.Mapper
{
    public class CategoryMappingProfile : Profile
    {
        public CategoryMappingProfile()
        {
            CreateMap<Category, CategoryDto>()
                .ForMember(dest => dest.BookIds, opt => opt.MapFrom(src => src.Books.Select(b => b.Id)));

            CreateMap<CategoryCreateDto, Category>();
            CreateMap<CategoryUpdateDto, Category>();
            CreateMap<CategoryDeleteDto, Category>();
        }
    }
}
