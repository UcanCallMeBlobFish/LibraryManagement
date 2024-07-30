using Application.Abstractions;
using Application.Features.Requests.Command.BookOnShelves;
using MediatR;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Handlers.Command.BookOnShelves
{

    public class DeleteBookOnShelvesCommandHandler : IRequestHandler<DeleteBookOnShelvesCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;

        public DeleteBookOnShelvesCommandHandler(IUnitOfWork unitOfWork, ILogger logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<Unit> Handle(DeleteBookOnShelvesCommand request, CancellationToken cancellationToken)
        {
            var bookOnShelves = await _unitOfWork.BookOnShelves.Get(request.Id);
            if (bookOnShelves == null)
            {
                _logger.Warn($"BookOnShelves with ID {request.Id} not found.");
                throw new KeyNotFoundException($"BookOnShelves with ID {request.Id} not found.");
            }

            await _unitOfWork.BookOnShelves.Delete(bookOnShelves);
            await _unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}
