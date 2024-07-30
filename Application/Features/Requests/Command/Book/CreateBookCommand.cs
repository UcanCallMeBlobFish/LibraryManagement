using Application.DTOs;
using MediatR;

namespace Application.Features.Requests.Command.Book
{
    public record CreateBookCommand(BookCreateDto BookCreateDto) : IRequest<int>;
}
