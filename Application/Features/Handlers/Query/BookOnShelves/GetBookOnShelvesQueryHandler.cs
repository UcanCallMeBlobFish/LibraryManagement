using Application.Abstractions.Library;
using Application.DTOs;
using Application.Features.Requests.Query.BookOnShelves;
using Application.Features.Requests.Query.Editor;
using Domain.Models;
using MediatR;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Handlers.Query.BookOnShelves
{
    public class GetBookOnShelvesQueryHandler : IRequestHandler<GetBookOnShelvesQuery, BookOnShelvesDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;
        public GetBookOnShelvesQueryHandler(IUnitOfWork unitOfWork, ILogger logger)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public async Task<BookOnShelvesDto> Handle(GetBookOnShelvesQuery request, CancellationToken cancellationToken)
        {
            var bookCopy = await _unitOfWork.BookOnShelves.Get(request.Id);
            if (bookCopy == null)
            {
                _logger.Warn($"BookCopy with ID {request.Id} not found.");
                return null;

            }
            return _unitOfWork.Mapper.Map<BookOnShelvesDto>(bookCopy);
        }
    }
}
