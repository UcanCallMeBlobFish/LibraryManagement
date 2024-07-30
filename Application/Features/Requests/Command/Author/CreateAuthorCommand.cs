using Application.DTOs;
using MediatR;

namespace Application.Features.Requests.Command.Author
{
    public record CreateAuthorCommand(AuthorCreateDto AuthorCreateDto) : IRequest<int>;
}
