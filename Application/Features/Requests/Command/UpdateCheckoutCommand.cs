using Application.DTOs;
using MediatR;

namespace Application.Features.Requests.Command
{
    public record UpdateCheckoutCommand(CheckoutUpdateDto CheckoutUpdateDto) : IRequest<Unit>;
}
