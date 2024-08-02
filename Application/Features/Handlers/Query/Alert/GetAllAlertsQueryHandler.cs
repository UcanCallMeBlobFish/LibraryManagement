using Application.Abstractions.Library;
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
    public class GetAllAlertsQueryHandler : IRequestHandler<GetAllAlertsQuery, IEnumerable<AlertDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;

        public GetAllAlertsQueryHandler(IUnitOfWork unitOfWork, ILogger logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<IEnumerable<AlertDto>> Handle(GetAllAlertsQuery request, CancellationToken cancellationToken)
        {
            var alerts = await _unitOfWork.Alerts.GetAll();
            return _unitOfWork.Mapper.Map<IEnumerable<AlertDto>>(alerts);
        }
    }
}
