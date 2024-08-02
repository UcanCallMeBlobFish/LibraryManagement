using Application.Abstractions.Library;
using Application.DTOs.Validations;
using Application.Features.Requests.Command.Checkout;
using MediatR;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Handlers.Command.Checkout
{
    public class CreateCheckoutCommandHandler : IRequestHandler<CreateCheckoutCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;

        public CreateCheckoutCommandHandler(IUnitOfWork unitOfWork, ILogger logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<int> Handle(CreateCheckoutCommand request, CancellationToken cancellationToken)
        {

            var validator = new CheckoutCreateDtoValidator();
            var validationResult = await validator.ValidateAsync(request.CheckoutCreateDto, cancellationToken);

            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    _logger.Warn(error.ErrorMessage);
                }
                throw new ArgumentException("Invalid CheckoutCreateDto provided.");
            }

            var checkout = _unitOfWork.Mapper.Map<Domain.Models.Checkout>(request.CheckoutCreateDto);
            await _unitOfWork.CheckOuts.Add(checkout);
            await _unitOfWork.SaveAsync();

            return checkout.Id;
        }
    }
}
