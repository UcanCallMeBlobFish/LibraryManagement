using MediatR;
using Application.DTOs;


namespace Application.Features.Requests.Query.Category
{
    public record GetCategoryQuery(int Id) : IRequest<CategoryDto>;


}
