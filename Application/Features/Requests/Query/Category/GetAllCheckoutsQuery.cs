using MediatR;
using Application.DTOs;


namespace Application.Features.Requests.Query.Category
{
    public record GetAllCheckoutsQuery() : IRequest<IEnumerable<CheckoutDto>>;


}
