using Application.Abstractions.Library;
using Application.Features.Requests.Command.Category;
using MediatR;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Handlers.Command.Category
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;

        public DeleteCategoryCommandHandler(IUnitOfWork unitOfWork, ILogger logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _unitOfWork.Categories.Get(request.Id);
            if (category == null)
            {
                _logger.Warn($"Category with ID {request.Id} not found.");
                throw new KeyNotFoundException($"Category with ID {request.Id} not found.");
            }

            await _unitOfWork.Categories.Delete(category);
            await _unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}
