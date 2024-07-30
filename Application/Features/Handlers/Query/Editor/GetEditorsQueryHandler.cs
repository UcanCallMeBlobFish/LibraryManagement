using Application.Abstractions;
using Application.DTOs;
using Application.Features.Requests.Query.Editor;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Handlers.Query.Editor
{
    public class GetEditorsQueryHandler : IRequestHandler<GetAllEditorsQuery, IEnumerable<EditorDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;
        public GetEditorsQueryHandler(IUnitOfWork unitOfWork, ILogger logger)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;   
        }
        public async Task<IEnumerable<EditorDto>> Handle(GetAllEditorsQuery request, CancellationToken cancellationToken)
        {
            var editors = await _unitOfWork.Editors.GetAll();
            return _unitOfWork.Mapper.Map<IEnumerable<EditorDto>>(editors);
        }

    }
}
