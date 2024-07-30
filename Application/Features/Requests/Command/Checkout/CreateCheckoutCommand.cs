using Application.DTOs;
using MediatR;

namespace Application.Features.Requests.Command.Checkout
{
    public record CreateCheckoutCommand(CheckoutCreateDto CheckoutCreateDto) : IRequest<int>;
}
