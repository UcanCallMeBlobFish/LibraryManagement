using Application.DTOs;
using MediatR;

namespace Application.Features.Requests.Command
{
    public record UpdateBookCommand(BookUpdateDto BookUpdateDto) : IRequest<Unit>;
}
