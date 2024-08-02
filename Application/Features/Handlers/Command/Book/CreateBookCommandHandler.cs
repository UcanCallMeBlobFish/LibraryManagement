using Application.Abstractions.Library;
using Application.DTOs.Validations;
using Application.Features.Requests.Command.Book;
using MediatR;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Handlers.Command.Book
{
    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;

        public CreateBookCommandHandler(IUnitOfWork unitOfWork, ILogger logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<int> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {

            var validator = new BookCreateDtoValidator();
            var validationResult = await validator.ValidateAsync(request.BookCreateDto, cancellationToken);

            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    _logger.Warn(error.ErrorMessage);
                }
                throw new ArgumentException("Invalid BookCreateDto provided.");
            }

            var book = _unitOfWork.Mapper.Map<Domain.Models.Book>(request.BookCreateDto);
            await _unitOfWork.Books.Add(book);
            await _unitOfWork.SaveAsync();

            return book.Id;
        }
    }
}
