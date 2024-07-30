using Application.DTOs;
using MediatR;

namespace Application.Features.Requests.Command.Alert
{
    public record CreateAlertCommand(AlertCreateDto AlertCreateDto) : IRequest<int>;
}
