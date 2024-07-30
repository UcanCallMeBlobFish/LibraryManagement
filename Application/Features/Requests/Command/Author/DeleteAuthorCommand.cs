using MediatR;

namespace Application.Features.Requests.Command.Author
{
    public record DeleteAuthorCommand(int Id) : IRequest<Unit>;
}
