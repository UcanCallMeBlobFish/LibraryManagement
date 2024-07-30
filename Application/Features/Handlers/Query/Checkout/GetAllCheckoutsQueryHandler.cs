using Application.Abstractions;
using Application.DTOs;
using Application.Features.Requests.Query.Category;
using Application.Features.Requests.Query.Checkout;
using Application.Features.Requests.Query.Editor;
using MediatR;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Handlers.Query.Checkout
{
    public class GetCheckoutsQueryHandler : IRequestHandler<GetAllCheckoutsQuery, IEnumerable<CheckoutDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;
        public GetCheckoutsQueryHandler(IUnitOfWork unitOfWork, ILogger logger)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<CheckoutDto>> Handle(GetAllCheckoutsQuery request, CancellationToken cancellationToken)
        {
            var checkouts = await _unitOfWork.CheckOuts.GetAll();
            return _unitOfWork.Mapper.Map<IEnumerable<CheckoutDto>>(checkouts);

        }
    }
}
