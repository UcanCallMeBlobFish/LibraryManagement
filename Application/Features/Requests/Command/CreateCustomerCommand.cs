using Application.DTOs;
using MediatR;

namespace Application.Features.Requests.Command
{
    public record CreateCustomerCommand(CustomerCreateDto CustomerCreateDto) : IRequest<int>;
}
