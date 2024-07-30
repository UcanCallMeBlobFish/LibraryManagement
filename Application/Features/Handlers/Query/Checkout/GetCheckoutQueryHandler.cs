using Application.Abstractions;
using Application.DTOs;
using Application.Features.Requests.Query.Checkout;
using Application.Features.Requests.Query.Editor;
using Domain.Models;
using MediatR;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Handlers.Query.Checkout
{
    public class GetCheckoutQueryHandler : IRequestHandler<GetCheckoutQuery, CheckoutDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;
        public GetCheckoutQueryHandler(IUnitOfWork unitOfWork, ILogger logger)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public async Task<CheckoutDto> Handle(GetCheckoutQuery request, CancellationToken cancellationToken)
        {
            var item = await _unitOfWork.CheckOuts.Get(request.Id);
            if (item == null)
            {
                _logger.Warn($"item with ID {request.Id} not found.");
                return null;

            }
            return _unitOfWork.Mapper.Map<CheckoutDto>(item);
        }
    }
}
