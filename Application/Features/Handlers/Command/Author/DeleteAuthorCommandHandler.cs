using Application.Abstractions.Library;
using Application.Features.Requests.Command.Author;
using MediatR;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Handlers.Command.Author
{
    public class DeleteAuthorCommandHandler : IRequestHandler<DeleteAuthorCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;

        public DeleteAuthorCommandHandler(IUnitOfWork unitOfWork, ILogger logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<Unit> Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
        {
            var author = await _unitOfWork.Authors.Get(request.Id);
            if (author == null)
            {
                _logger.Warn($"Author with ID {request.Id} not found.");
                throw new KeyNotFoundException($"Author with ID {request.Id} not found.");
            }

            await _unitOfWork.Authors.Delete(author);
            await _unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}
