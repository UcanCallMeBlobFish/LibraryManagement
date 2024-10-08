﻿using Application.Abstractions.Library;
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
    public class UpdateCheckoutCommandHandler : IRequestHandler<UpdateCheckoutCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;

        public UpdateCheckoutCommandHandler(IUnitOfWork unitOfWork, ILogger logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<Unit> Handle(UpdateCheckoutCommand request, CancellationToken cancellationToken)
        {

            var validator = new CheckoutUpdateDtoValidator();
            var validationResult = await validator.ValidateAsync(request.CheckoutUpdateDto, cancellationToken);

            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    _logger.Warn(error.ErrorMessage);
                }
                throw new ArgumentException("Invalid CheckoutUpdateDto provided.");
            }

            var checkout = await _unitOfWork.CheckOuts.Get(request.CheckoutUpdateDto.Id);
            if (checkout == null)
            {
                _logger.Warn($"Checkout with ID {request.CheckoutUpdateDto.Id} not found.");
                throw new KeyNotFoundException($"Checkout with ID {request.CheckoutUpdateDto.Id} not found.");
            }

            _unitOfWork.Mapper.Map(request.CheckoutUpdateDto, checkout);
            await _unitOfWork.CheckOuts.Update(checkout);
            await _unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}
