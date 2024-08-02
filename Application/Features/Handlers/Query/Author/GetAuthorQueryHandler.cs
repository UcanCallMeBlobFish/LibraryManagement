using Application.Abstractions.Library;
using Application.DTOs;
using Application.Features.Requests.Query.Author;
using MediatR;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Handlers.Query.Author
{
    public class GetAuthorQueryHandler : IRequestHandler<GetAuthorQuery, AuthorDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;

        public GetAuthorQueryHandler(IUnitOfWork unitOfWork, ILogger logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<AuthorDto> Handle(GetAuthorQuery request, CancellationToken cancellationToken)
        {
            var author = await _unitOfWork.Authors.Get(request.Id);
            if (author == null)
            {
                // Handle the case where the author is not found (e.g., return null or throw an exception)
                _logger.Warn($"Author with ID {request.Id} not found.");
                return null; // or throw a custom exception if preferred
            }

            return _unitOfWork.Mapper.Map<AuthorDto>(author);
        }
    }
}
