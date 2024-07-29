using Application.DTOs;
using MediatR;

namespace Application.Features.Requests.Command
{
    public record CreateBookCommand(BookCreateDto BookCreateDto) : IRequest<int>;
}
