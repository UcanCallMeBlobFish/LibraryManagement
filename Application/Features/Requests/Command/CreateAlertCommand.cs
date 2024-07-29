using Application.DTOs;
using MediatR;

namespace Application.Features.Requests.Command
{
    public record CreateAlertCommand(AlertCreateDto AlertCreateDto) : IRequest<int>;
}
