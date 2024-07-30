using Application.DTOs;
using MediatR;

namespace Application.Features.Requests.Command.Alert
{
    public record UpdateAlertCommand(AlertUpdateDto AlertUpdateDto) : IRequest<Unit>;
}
