using Application.Abstractions.Library;
using Application.DTOs.Validations;
using Application.Features.Requests.Command.Author;
using MediatR;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Handlers.Command.Author
{
    public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;

        public UpdateAuthorCommandHandler(IUnitOfWork unitOfWork, ILogger logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<Unit> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
        {

            var validator = new AuthorUpdateDtoValidator();
            var validationResult = await validator.ValidateAsync(request.AuthorUpdateDto, cancellationToken);

            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    _logger.Warn(error.ErrorMessage);
                }
                throw new ArgumentException("Invalid AuthorUpdateDto provided.");
            }

            var author = await _unitOfWork.Authors.Get(request.AuthorUpdateDto.Id);
            if (author == null)
            {
                _logger.Warn($"Author with ID {request.AuthorUpdateDto.Id} not found.");
                throw new KeyNotFoundException($"Author with ID {request.AuthorUpdateDto.Id} not found.");
            }

            _unitOfWork.Mapper.Map(request.AuthorUpdateDto, author);
            await _unitOfWork.Authors.Update(author);
            await _unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}
