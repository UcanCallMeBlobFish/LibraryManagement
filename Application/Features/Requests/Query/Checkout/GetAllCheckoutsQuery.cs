using MediatR;
using Application.DTOs;


namespace Application.Features.Requests.Query.Checkout
{
    public record GetAllCheckoutsQuery() : IRequest<IEnumerable<CheckoutDto>>;


}
