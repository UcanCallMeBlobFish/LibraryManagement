using Application.Abstractions;
using Application.DTOs.Validations;
using Application.Features.Requests.Command.BookOnShelves;
using MediatR;
using NLog;

namespace Application.Features.Handlers.Command.BookOnShelves
{
    public class CreateBookOnShelvesCommandHandler : IRequestHandler<CreateBookOnShelvesCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;

        public CreateBookOnShelvesCommandHandler(IUnitOfWork unitOfWork, ILogger logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<int> Handle(CreateBookOnShelvesCommand request, CancellationToken cancellationToken)
        {

            var validator = new BookOnShelvesCreateDtoValidator();
            var validationResult = await validator.ValidateAsync(request.BookOnShelvesCreateDto, cancellationToken);

            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    _logger.Warn(error.ErrorMessage);
                }
                throw new ArgumentException("Invalid BookOnShelvesCreateDto provided.");
            }

            var bookOnShelves = _unitOfWork.Mapper.Map<Domain.Models.BookOnShelves>(request.BookOnShelvesCreateDto);
            await _unitOfWork.BookOnShelves.Add(bookOnShelves);
            await _unitOfWork.SaveAsync();

            return bookOnShelves.Id;
        }
    }
}
