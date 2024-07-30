using Application.Abstractions;
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
    public class CreateAlertCommandHandler : IRequestHandler<CreateAlertCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;

        public CreateAlertCommandHandler(IUnitOfWork unitOfWork, ILogger logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<int> Handle(CreateAlertCommand request, CancellationToken cancellationToken)
        {

            var validator = new AlertCreateDtoValidator();
            var validationResult = await validator.ValidateAsync(request.AlertCreateDto, cancellationToken);

            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    _logger.Warn(error.ErrorMessage);
                }
                throw new ArgumentException("custom");
            }

            var alert = _unitOfWork.Mapper.Map<Domain.Models.Alert>(request.AlertCreateDto);
            await _unitOfWork.Alerts.Add(alert);
            await _unitOfWork.SaveAsync();

            return alert.Id;
        }
    }
}
