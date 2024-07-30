using Application.DTOs;
using MediatR;

namespace Application.Features.Requests.Command.BookOnShelves
{
    public record CreateBookOnShelvesCommand(BookOnShelvesCreateDto BookOnShelvesCreateDto) : IRequest<int>;
}
