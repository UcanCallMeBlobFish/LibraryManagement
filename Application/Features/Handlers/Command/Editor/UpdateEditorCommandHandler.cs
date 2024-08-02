using Application.Abstractions.Library;
using Application.DTOs.Validations;
using Application.Features.Requests.Command.Editor;
using MediatR;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Handlers.Command.Editor
{
    public class UpdateEditorCommandHandler : IRequestHandler<UpdateEditorCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;

        public UpdateEditorCommandHandler(IUnitOfWork unitOfWork, ILogger logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<Unit> Handle(UpdateEditorCommand request, CancellationToken cancellationToken)
        {

            var validator = new EditorUpdateDtoValidator();
            var validationResult = await validator.ValidateAsync(request.EditorUpdateDto, cancellationToken);

            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    _logger.Warn(error.ErrorMessage);
                }
                throw new ArgumentException("Invalid EditorUpdateDto provided.");
            }

            var editor = await _unitOfWork.Editors.Get(request.EditorUpdateDto.Id);
            if (editor == null)
            {
                _logger.Warn($"Editor with ID {request.EditorUpdateDto.Id} not found.");
                throw new KeyNotFoundException($"Editor with ID {request.EditorUpdateDto.Id} not found.");
            }

            _unitOfWork.Mapper.Map(request.EditorUpdateDto, editor);
            await _unitOfWork.Editors.Update(editor);
            await _unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}
