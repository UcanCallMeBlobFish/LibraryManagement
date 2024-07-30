using Application.Abstractions;
using Application.DTOs.Validations;
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
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;

        public UpdateCategoryCommandHandler(IUnitOfWork unitOfWork, ILogger logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<Unit> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {

            var validator = new CategoryUpdateDtoValidator();
            var validationResult = await validator.ValidateAsync(request.CategoryUpdateDto, cancellationToken);

            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    _logger.Warn(error.ErrorMessage);
                }
                throw new ArgumentException("Invalid CategoryUpdateDto provided.");
            }

            var category = await _unitOfWork.Categories.Get(request.CategoryUpdateDto.Id);
            if (category == null)
            {
                _logger.Warn($"Category with ID {request.CategoryUpdateDto.Id} not found.");
                throw new KeyNotFoundException($"Category with ID {request.CategoryUpdateDto.Id} not found.");
            }

            _unitOfWork.Mapper.Map(request.CategoryUpdateDto, category);
            await _unitOfWork.Categories.Update(category);
            await _unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}
