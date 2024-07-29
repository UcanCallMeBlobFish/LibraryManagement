using Application.DTOs;
using MediatR;

namespace Application.Features.Requests.Command
{
    public record CreateCheckoutCommand(CheckoutCreateDto CheckoutCreateDto) : IRequest<int>;
}
