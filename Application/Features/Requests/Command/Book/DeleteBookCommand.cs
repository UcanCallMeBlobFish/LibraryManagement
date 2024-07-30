using MediatR;

namespace Application.Features.Requests.Command.Book
{
    public record DeleteBookCommand(int Id) : IRequest<Unit>;
}
