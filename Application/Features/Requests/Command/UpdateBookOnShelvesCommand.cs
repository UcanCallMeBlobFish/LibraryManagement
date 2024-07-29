using Application.DTOs;
using MediatR;

namespace Application.Features.Requests.Command
{
    public record UpdateBookOnShelvesCommand(BookOnShelvesUpdateDto BookOnShelvesUpdateDto) : IRequest<Unit>;
}
