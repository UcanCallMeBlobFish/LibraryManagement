using MediatR;
using Application.DTOs;


namespace Application.Features.Requests.Query.Category
{
    public record GetAllCategoriesQuery() : IRequest<IEnumerable<CategoryDto>>;


}
