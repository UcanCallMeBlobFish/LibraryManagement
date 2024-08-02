using Application.Abstractions.Library;
using Application.DTOs;
using Application.Features.Requests.Query.Category;
using Application.Features.Requests.Query.Editor;
using MediatR;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Handlers.Query.Category
{
    public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQuery, CategoryDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;
        public GetCategoryQueryHandler(IUnitOfWork unitOfWork, ILogger logger)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public async Task<CategoryDto> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
        {
            var category = await _unitOfWork.Categories.Get(request.Id);
            if (category == null)
            {
                _logger.Warn($"category with ID {request.Id} not found.");
                return null;

            }
            return _unitOfWork.Mapper.Map<CategoryDto>(category);
        }
    }
}
