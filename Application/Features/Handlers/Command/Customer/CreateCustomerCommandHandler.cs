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
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, string>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;

        public CreateCustomerCommandHandler(IUnitOfWork unitOfWork, ILogger logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<string> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {

            var validator = new CustomerCreateDtoValidator();
            var validationResult = await validator.ValidateAsync(request.CustomerCreateDto, cancellationToken);

            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    _logger.Warn(error.ErrorMessage);
                }
                throw new ArgumentException("Invalid CustomerCreateDto provided.");
            }

            var customer = _unitOfWork.Mapper.Map<Domain.Models.Customer>(request.CustomerCreateDto);
            await _unitOfWork.Customers.Add(customer);
            await _unitOfWork.SaveAsync();

            return customer.Username;
        }
    }
}
