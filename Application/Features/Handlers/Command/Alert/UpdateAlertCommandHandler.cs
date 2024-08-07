using Application.Abstractions.Library;
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

        public UpdateAlertCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(UpdateAlertCommand request, CancellationToken cancellationToken)
        {
            var validator = new AlertUpdateDtoValidator();
            var validationResult = await validator.ValidateAsync(request.AlertUpdateDto, cancellationToken);

            if (!validationResult.IsValid)  throw new ArgumentException("Invalid AlertUpdateDto provided.");
            

            var alert = await _unitOfWork.Alerts.Get(request.AlertUpdateDto.Id);
            if (alert == null)
            {
                throw new KeyNotFoundException($"Alert with ID {request.AlertUpdateDto.Id} not found.");
            }

            _unitOfWork.Mapper.Map(request.AlertUpdateDto, alert);
            await _unitOfWork.Alerts.Update(alert);
            await _unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}
