using Application.Abstractions.Library;
using Application.DTOs.Validations;
using Application.Features.Requests.Command.Book;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Handlers.Command.Book
{
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateBookCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var validator = new BookUpdateDtoValidator();
            var validationResult = await validator.ValidateAsync(request.BookUpdateDto, cancellationToken);

            if (!validationResult.IsValid)
            {
                throw new ArgumentException("Invalid BookUpdateDto provided.");
            }

            var book = await _unitOfWork.Books.Get(request.BookUpdateDto.Id);
            if (book == null)
            {
                throw new KeyNotFoundException($"Book with ID {request.BookUpdateDto.Id} not found.");
            }

            _unitOfWork.Mapper.Map(request.BookUpdateDto, book);
            await _unitOfWork.Books.Update(book);
            await _unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}
