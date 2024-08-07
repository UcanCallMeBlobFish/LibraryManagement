using Application.Abstractions.Library;
using Application.DTOs.Validations;
using Application.Features.Requests.Command.Author;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Handlers.Command.Author
{
    public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateAuthorCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
        {
            var validator = new AuthorUpdateDtoValidator();
            var validationResult = await validator.ValidateAsync(request.AuthorUpdateDto, cancellationToken);

            if (!validationResult.IsValid)
            {
                throw new ArgumentException("Invalid AuthorUpdateDto provided.");
            }

            var author = await _unitOfWork.Authors.Get(request.AuthorUpdateDto.Id);
            if (author == null)
            {
                throw new KeyNotFoundException($"Author with ID {request.AuthorUpdateDto.Id} not found.");
            }

            _unitOfWork.Mapper.Map(request.AuthorUpdateDto, author);
            await _unitOfWork.Authors.Update(author);
            await _unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}
