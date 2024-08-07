using Application.Abstractions.Library;
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
    public class DeleteAlertCommandHandler : IRequestHandler<DeleteAlertCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteAlertCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteAlertCommand request, CancellationToken cancellationToken)
        {
            var alert = await _unitOfWork.Alerts.Get(request.Id);
         
            if (alert == null)  throw new KeyNotFoundException($"Alert with ID {request.Id} not found.");
            

            await _unitOfWork.Alerts.Delete(alert);
            await _unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}
