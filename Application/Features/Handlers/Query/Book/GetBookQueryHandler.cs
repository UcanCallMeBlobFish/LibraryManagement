using Application.Abstractions;
using Application.DTOs;
using Application.Features.Requests.Query.Book;
using Application.Features.Requests.Query.Editor;
using MediatR;
using NLog;
using NLog.Fluent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Handlers.Query.Book
{
    public class GetBookQueryHandler : IRequestHandler<GetBookQuery, BookDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;
        public GetBookQueryHandler(IUnitOfWork unitOfWork, ILogger logger)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public async Task<BookDto> Handle(GetBookQuery request, CancellationToken cancellationToken)
        {
            var book = await _unitOfWork.Books.Get(request.Id);
            if (book == null)
            {
                _logger.Warn($"Alert with ID {request.Id} not found.");
                return null;

            }
            return _unitOfWork.Mapper.Map<BookDto>(book);
        }
    }
}
