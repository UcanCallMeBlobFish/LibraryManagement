using Application.DTOs;
using MediatR;

namespace Application.Features.Requests.Command.Book
{
    public record UpdateBookCommand(BookUpdateDto BookUpdateDto) : IRequest<Unit>;
}
