using Application.DTOs;
using MediatR;

namespace Application.Features.Requests.Command.Checkout
{
    public record UpdateCheckoutCommand(CheckoutUpdateDto CheckoutUpdateDto) : IRequest<Unit>;
}
