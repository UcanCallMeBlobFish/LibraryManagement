using Application.DTOs;
using MediatR;

namespace Application.Features.Requests.Command.Author
{
    public record UpdateAuthorCommand(AuthorUpdateDto AuthorUpdateDto) : IRequest<Unit>;
}
