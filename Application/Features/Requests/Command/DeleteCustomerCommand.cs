using MediatR;

namespace Application.Features.Requests.Command
{
    public record DeleteCustomerCommand(string Username) : IRequest<Unit>;
}
