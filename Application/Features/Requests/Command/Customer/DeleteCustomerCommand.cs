using MediatR;

namespace Application.Features.Requests.Command.Customer
{
    public record DeleteCustomerCommand(string Username) : IRequest<Unit>;
}
