using MediatR;

namespace Application.Features.Requests.Command
{
    public record DeleteBookCommand(int Id) : IRequest<Unit>;
}
