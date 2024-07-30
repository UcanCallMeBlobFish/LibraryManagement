using Application.DTOs;
using MediatR;

namespace Application.Features.Requests.Command.Customer
{
    public record CreateCustomerCommand(CustomerCreateDto CustomerCreateDto) : IRequest<string>;
}
