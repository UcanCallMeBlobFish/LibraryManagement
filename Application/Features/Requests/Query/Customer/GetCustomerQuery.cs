using MediatR;
using Application.DTOs;


namespace Application.Features.Requests.Query.Customer
{
    public record GetCustomerQuery(string Username) : IRequest<CustomerDto>;


}
