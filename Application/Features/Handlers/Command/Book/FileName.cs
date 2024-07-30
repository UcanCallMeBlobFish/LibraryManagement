using Application.Abstractions;
using Application.Features.Requests.Command.Book;
using MediatR;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Handlers.Command.Book
{
    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;

        public DeleteBookCommandHandler(IUnitOfWork unitOfWork, ILogger logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<Unit> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _unitOfWork.Books.Get(request.Id);
            if (book == null)
            {
                _logger.Warn($"Book with ID {request.Id} not found.");
                throw new KeyNotFoundException($"Book with ID {request.Id} not found.");
            }

            await _unitOfWork.Books.Delete(book);
            await _unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}
