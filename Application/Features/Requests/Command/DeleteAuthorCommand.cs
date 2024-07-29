using MediatR;

namespace Application.Features.Requests.Command
{
    public record DeleteAuthorCommand(int Id) : IRequest<Unit>;
}
