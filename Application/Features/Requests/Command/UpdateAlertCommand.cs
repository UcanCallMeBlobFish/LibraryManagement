using Application.DTOs;
using MediatR;

namespace Application.Features.Requests.Command
{
    public record UpdateAlertCommand(AlertUpdateDto AlertUpdateDto) : IRequest<Unit>;
}
