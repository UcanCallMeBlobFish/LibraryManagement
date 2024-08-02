using Application.Abstractions.Library;
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
    public class DeleteCheckoutCommandHandler : IRequestHandler<DeleteCheckoutCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;

        public DeleteCheckoutCommandHandler(IUnitOfWork unitOfWork, ILogger logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<Unit> Handle(DeleteCheckoutCommand request, CancellationToken cancellationToken)
        {
            var checkout = await _unitOfWork.CheckOuts.Get(request.Id);
            if (checkout == null)
            {
                _logger.Warn($"Checkout with ID {request.Id} not found.");
                throw new KeyNotFoundException($"Checkout with ID {request.Id} not found.");
            }

            await _unitOfWork.CheckOuts.Delete(checkout);
            await _unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}
