using Application.Abstractions;
using Application.DTOs;
using Application.Features.Requests.Query.Alert;
using MediatR;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Handlers.Query.Alert
{
    public class GetAlertQueryHandler : IRequestHandler<GetAlertQuery, AlertDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;

        public GetAlertQueryHandler(IUnitOfWork unitOfWork, ILogger logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<AlertDto> Handle(GetAlertQuery request, CancellationToken cancellationToken)
        {
            var alert = await _unitOfWork.Alerts.Get(request.Id);
            if (alert == null)
            {
                // Handle the case where the alert is not found (e.g., return null or throw an exception)
                _logger.Warn($"Alert with ID {request.Id} not found.");
                return null; // or throw a custom exception if preferred
            }

            return _unitOfWork.Mapper.Map<AlertDto>(alert);
        }
    }
}
