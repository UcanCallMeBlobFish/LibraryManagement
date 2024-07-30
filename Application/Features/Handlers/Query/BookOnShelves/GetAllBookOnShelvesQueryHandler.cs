using Application.Abstractions;
using Application.DTOs;
using Application.Features.Requests.Query.BookOnShelves;
using Application.Features.Requests.Query.Editor;
using MediatR;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Handlers.Query.BookOnShelves
{
    public class GetAllBookOnShelvesQueryHandler : IRequestHandler<GetAllBookOnShelvesQuery, IEnumerable<BookOnShelvesDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;
        public GetAllBookOnShelvesQueryHandler(IUnitOfWork unitOfWork, ILogger logger)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<BookOnShelvesDto>> Handle(GetAllBookOnShelvesQuery request, CancellationToken cancellationToken)
        {
            var booksOnshelves = await _unitOfWork.BookOnShelves.GetAll();
            return _unitOfWork.Mapper.Map<IEnumerable<BookOnShelvesDto>>(booksOnshelves);
        }
    }
}
