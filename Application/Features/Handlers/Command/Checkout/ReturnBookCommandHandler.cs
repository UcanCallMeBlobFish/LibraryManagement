using Application.Abstractions.Library;
using Application.Features.Requests.Command.Checkout;
using MediatR;
using NLog;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Handlers.Command.Checkout
{
    public class ReturnBookCommandHandler : IRequestHandler<ReturnBookCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;

        public ReturnBookCommandHandler(IUnitOfWork unitOfWork, ILogger logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<int> Handle(ReturnBookCommand request, CancellationToken cancellationToken)
        {
            var checkout = await _unitOfWork.CheckOuts.Get(request.Id);

            if (checkout == null)
            {
                _logger.Warn($"Checkout with ID {request.Id} not found.");
                throw new ArgumentException("Invalid CheckoutId provided.");
            }

            if (checkout.IsReturned)
            {
                _logger.Warn($"Book with Checkout ID {request.Id} has already been returned.");
                throw new InvalidOperationException("This book has already been returned.");
            }

            checkout.IsReturned = true;
            checkout.ReturnDate = DateTime.UtcNow;

            var bookOnShelves = await _unitOfWork.BookOnShelves.Get(checkout.BookOnShelvesId);

            if (bookOnShelves != null)
            {
                bookOnShelves.IsAvailable = true;
            }

            await _unitOfWork.SaveAsync();

            return checkout.Id;
        }
    }
}
