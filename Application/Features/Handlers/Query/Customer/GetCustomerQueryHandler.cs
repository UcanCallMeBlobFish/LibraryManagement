using Application.Abstractions.Library;
using Application.DTOs;
using Application.Features.Requests.Query.Customer;
using MediatR;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Handlers.Query.Customer
{
    public class GetCustomerQueryHandler : IRequestHandler<GetCustomerQuery, CustomerDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;
        public GetCustomerQueryHandler(IUnitOfWork unitOfWork, ILogger logger)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }
        public async Task<CustomerDto> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
        {
            var customers = await _unitOfWork.Customers.GetAll();

            var customer = customers.FirstOrDefault(c => c.Username == request.Username);

            if (customer == null)
            {
                _logger.Warn($"customer with ID {request.Username} not found.");
                return null;

            }
            return _unitOfWork.Mapper.Map<CustomerDto>(customer);

        }
    }
}
