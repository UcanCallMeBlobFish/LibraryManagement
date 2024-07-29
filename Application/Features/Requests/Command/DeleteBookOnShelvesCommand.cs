using MediatR;

namespace Application.Features.Requests.Command
{
    public record DeleteBookOnShelvesCommand(int Id) : IRequest<Unit>;
}
