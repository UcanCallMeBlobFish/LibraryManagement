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
    public class CreateEditorCommandHandler : IRequestHandler<CreateEditorCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;

        public CreateEditorCommandHandler(IUnitOfWork unitOfWork, ILogger logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<int> Handle(CreateEditorCommand request, CancellationToken cancellationToken)
        {

            var validator = new EditorCreateDtoValidator();
            var validationResult = await validator.ValidateAsync(request.EditorCreateDto, cancellationToken);

            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    _logger.Warn(error.ErrorMessage);
                }
                throw new ArgumentException("Invalid EditorCreateDto provided.");
            }

            var editor = _unitOfWork.Mapper.Map<Domain.Models.Editor>(request.EditorCreateDto);
            await _unitOfWork.Editors.Add(editor);
            await _unitOfWork.SaveAsync();

            return editor.Id;
        }
    }
}
