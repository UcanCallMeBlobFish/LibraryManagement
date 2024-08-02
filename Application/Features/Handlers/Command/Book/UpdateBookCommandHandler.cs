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
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;

        public UpdateBookCommandHandler(IUnitOfWork unitOfWork, ILogger logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<Unit> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {

            var validator = new BookUpdateDtoValidator();
            var validationResult = await validator.ValidateAsync(request.BookUpdateDto, cancellationToken);

            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    _logger.Warn(error.ErrorMessage);
                }
                throw new ArgumentException("Invalid BookUpdateDto provided.");
            }

            var book = await _unitOfWork.Books.Get(request.BookUpdateDto.Id);
            if (book == null)
            {
                _logger.Warn($"Book with ID {request.BookUpdateDto.Id} not found.");
                throw new KeyNotFoundException($"Book with ID {request.BookUpdateDto.Id} not found.");
            }

            _unitOfWork.Mapper.Map(request.BookUpdateDto, book);
            await _unitOfWork.Books.Update(book);
            await _unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}
