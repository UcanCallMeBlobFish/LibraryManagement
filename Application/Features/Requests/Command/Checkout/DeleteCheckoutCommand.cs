using MediatR;

namespace Application.Features.Requests.Command.Checkout
{
    public record DeleteCheckoutCommand(int Id) : IRequest<Unit>;
}
