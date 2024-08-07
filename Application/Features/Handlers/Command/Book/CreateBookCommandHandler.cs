using Application.Abstractions.Library;
using Application.DTOs.Validations;
using Application.Features.Requests.Command.Book;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Handlers.Command.Book
{
    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateBookCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var validator = new BookCreateDtoValidator();
            var validationResult = await validator.ValidateAsync(request.BookCreateDto, cancellationToken);

            if (!validationResult.IsValid)
            {
                throw new ArgumentException("Invalid BookCreateDto provided.");
            }

            var book = _unitOfWork.Mapper.Map<Domain.Models.Book>(request.BookCreateDto);
            await _unitOfWork.Books.Add(book);
            await _unitOfWork.SaveAsync();

            return book.Id;
        }
    }
}
