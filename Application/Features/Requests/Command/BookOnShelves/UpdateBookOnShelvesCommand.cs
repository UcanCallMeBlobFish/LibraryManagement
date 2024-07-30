using Application.DTOs;
using MediatR;

namespace Application.Features.Requests.Command.BookOnShelves
{
    public record UpdateBookOnShelvesCommand(BookOnShelvesUpdateDto BookOnShelvesUpdateDto) : IRequest<Unit>;
}
