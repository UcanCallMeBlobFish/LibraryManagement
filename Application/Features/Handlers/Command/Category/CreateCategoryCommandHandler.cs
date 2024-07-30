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
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;

        public CreateCategoryCommandHandler(IUnitOfWork unitOfWork, ILogger logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<int> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {

            var validator = new CategoryCreateDtoValidator();
            var validationResult = await validator.ValidateAsync(request.CategoryCreateDto, cancellationToken);

            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    _logger.Warn(error.ErrorMessage);
                }
                throw new ArgumentException("Invalid CategoryCreateDto provided.");
            }

            var category = _unitOfWork.Mapper.Map<Domain.Models.Category>(request.CategoryCreateDto);
            await _unitOfWork.Categories.Add(category);
            await _unitOfWork.SaveAsync();

            return category.Id;
        }
    }
}
