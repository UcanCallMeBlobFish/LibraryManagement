using Application.Abstractions;
using Application.DTOs;
using Application.DTOs.Validations;
using Application.Features.Requests.Query.Editor;
using Domain.Models;
using FluentValidation;
using MediatR;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Handlers.Query.Editor
{
    public class GetEditorByIdQueryHandler : IRequestHandler<GetEditorQuery, EditorDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;

        public GetEditorByIdQueryHandler(IUnitOfWork unitOfWork, ILogger logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<EditorDto> Handle(GetEditorQuery request, CancellationToken cancellationToken)
        {

            {
                var editor = await _unitOfWork.Editors.Get(request.Id);

                if (editor == null)
                {
                    _logger.Warn($"editor with ID {request.Id} not found.");
                    return null;

                }
                return _unitOfWork.Mapper.Map<EditorDto>(editor);
            }
        }
    }
}
