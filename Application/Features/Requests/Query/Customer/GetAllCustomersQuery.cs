using MediatR;
using Application.DTOs;


namespace Application.Features.Requests.Query.Customer
{
    public record GetAllCustomersQuery() : IRequest<IEnumerable<CustomerDto>>;


}
