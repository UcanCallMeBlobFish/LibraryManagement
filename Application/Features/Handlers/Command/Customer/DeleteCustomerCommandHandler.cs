using Application.Abstractions;
using Application.Features.Requests.Command.Customer;
using MediatR;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Handlers.Command.Customer
{
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;

        public DeleteCustomerCommandHandler(IUnitOfWork unitOfWork, ILogger logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<Unit> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await _unitOfWork.Customers.Get(request.Username);
            if (customer == null)
            {
                _logger.Warn($"Customer with Username {request.Username} not found.");
                throw new KeyNotFoundException($"Customer with Username {request.Username} not found.");
            }

            await _unitOfWork.Customers.Delete(customer);
            await _unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}
