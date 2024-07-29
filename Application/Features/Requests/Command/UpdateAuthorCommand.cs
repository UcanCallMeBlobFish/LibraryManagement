using Application.DTOs;
using MediatR;

namespace Application.Features.Requests.Command
{
    public record UpdateAuthorCommand(AuthorUpdateDto AuthorUpdateDto) : IRequest<Unit>;
}
