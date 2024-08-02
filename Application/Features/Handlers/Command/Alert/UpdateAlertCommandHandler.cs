﻿using Application.Abstractions.Library;
using Application.DTOs.Validations;
using Application.Features.Requests.Command.Alert;
using MediatR;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Handlers.Command.Alert
{
    public class UpdateAlertCommandHandler : IRequestHandler<UpdateAlertCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;

        public UpdateAlertCommandHandler(IUnitOfWork unitOfWork, ILogger logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<Unit> Handle(UpdateAlertCommand request, CancellationToken cancellationToken)
        {
            var validator = new AlertUpdateDtoValidator();
            var validationResult = await validator.ValidateAsync(request.AlertUpdateDto, cancellationToken);

            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    _logger.Warn(error.ErrorMessage);
                }
                throw new ArgumentException("Invalid AlertUpdateDto provided.");
            }

            var alert = await _unitOfWork.Alerts.Get(request.AlertUpdateDto.Id);
            if (alert == null)
            {
                _logger.Warn($"Alert with ID {request.AlertUpdateDto.Id} not found.");
                throw new KeyNotFoundException($"Alert with ID {request.AlertUpdateDto.Id} not found.");
            }

            _unitOfWork.Mapper.Map(request.AlertUpdateDto, alert);
            await _unitOfWork.Alerts.Update(alert);
            await _unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}
