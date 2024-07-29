using MediatR;
using Application.DTOs;


namespace Application.Features.Requests.Query.Checkout
{
    public record GetCategoryQuery(int Id) : IRequest<CategoryDto>;


}
