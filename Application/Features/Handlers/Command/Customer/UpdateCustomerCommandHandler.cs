using Application.Abstractions.Library;
using Application.DTOs.Validations;
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
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;

        public UpdateCustomerCommandHandler(IUnitOfWork unitOfWork, ILogger logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<Unit> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            // Create validator and validate the request
            var validator = new CustomerUpdateDtoValidator();
            var validationResult = await validator.ValidateAsync(request.CustomerUpdateDto, cancellationToken);

            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    _logger.Warn(error.ErrorMessage);
                }
                throw new ArgumentException("Invalid CustomerUpdateDto provided.");
            }

            var customer = await _unitOfWork.Customers.Get(request.CustomerUpdateDto.Username);
            if (customer == null)
            {
                _logger.Warn($"Customer with ID {request.CustomerUpdateDto.Username} not found.");
                throw new KeyNotFoundException($"Customer with ID {request.CustomerUpdateDto.Username} not found.");
            }

            _unitOfWork.Mapper.Map(request.CustomerUpdateDto, customer);
            await _unitOfWork.Customers.Update(customer);
            await _unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}
