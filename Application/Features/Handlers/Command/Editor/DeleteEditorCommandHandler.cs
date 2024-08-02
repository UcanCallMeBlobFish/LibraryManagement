using Application.Abstractions.Library;
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
    public class DeleteEditorCommandHandler : IRequestHandler<DeleteEditorCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;

        public DeleteEditorCommandHandler(IUnitOfWork unitOfWork, ILogger logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<Unit> Handle(DeleteEditorCommand request, CancellationToken cancellationToken)
        {
            var editor = await _unitOfWork.Editors.Get(request.Id);
            if (editor == null)
            {
                _logger.Warn($"Editor with ID {request.Id} not found.");
                throw new KeyNotFoundException($"Editor with ID {request.Id} not found.");
            }

            await _unitOfWork.Editors.Delete(editor);
            await _unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}
