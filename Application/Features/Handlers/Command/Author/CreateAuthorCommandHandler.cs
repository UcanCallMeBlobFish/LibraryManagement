using Application.Abstractions;
using Application.DTOs.Validations;
using Application.Features.Requests.Command.Author;
using MediatR;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Application.Features.Handlers.Command.Author
{
    public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;

        public CreateAuthorCommandHandler(IUnitOfWork unitOfWork, ILogger logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<int> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
        {
            var validator = new AuthorCreateDtoValidator();
            var validationResult = await validator.ValidateAsync(request.AuthorCreateDto, cancellationToken);

            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    _logger.Warn(error.ErrorMessage);
                }
                throw new ArgumentException("Invalid AuthorCreateDto provided.");
            }

            var author = _unitOfWork.Mapper.Map<Domain.Models.Author>(request.AuthorCreateDto);
            await _unitOfWork.Authors.Add(author);
            await _unitOfWork.SaveAsync();

            return author.Id;
        }
    }
}
