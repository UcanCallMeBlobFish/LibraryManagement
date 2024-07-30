using MediatR;

namespace Application.Features.Requests.Command.BookOnShelves
{
    public record DeleteBookOnShelvesCommand(int Id) : IRequest<Unit>;
}
