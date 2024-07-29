using MediatR;

namespace Application.Features.Requests.Command
{
    public record DeleteCheckoutCommand(int Id) : IRequest<Unit>;
}
