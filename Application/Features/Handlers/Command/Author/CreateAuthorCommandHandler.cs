using Application.DTOs.Validations;
using Application.Features.Requests.Command.Author;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Domain.Models;
using Application.Abstractions.Library;

namespace Application.Features.Handlers.Command.Author
{
    public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateAuthorCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
        {
            var validator = new AuthorCreateDtoValidator();
            var validationResult = await validator.ValidateAsync(request.AuthorCreateDto, cancellationToken);

            if (!validationResult.IsValid)
            {
                throw new ArgumentException("Invalid AuthorCreateDto provided.");
            }

            var author = _unitOfWork.Mapper.Map<Domain.Models.Author>(request.AuthorCreateDto);
            await _unitOfWork.Authors.Add(author);
            await _unitOfWork.SaveAsync();

            return author.Id;
        }
    }
}
