using Application.DTOs;
using MediatR;

namespace Application.Features.Requests.Command.Customer
{
    public record UpdateCustomerCommand(CustomerUpdateDto CustomerUpdateDto) : IRequest<Unit>;
}
