using MediatR;
using Application.DTOs;


namespace Application.Features.Requests.Query.Checkout
{
    public record GetCheckoutQuery(int Id) : IRequest<CheckoutDto>;


}
