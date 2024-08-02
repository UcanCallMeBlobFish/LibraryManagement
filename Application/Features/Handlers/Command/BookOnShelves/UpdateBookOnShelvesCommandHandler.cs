using Application.Abstractions.Library;
using Application.DTOs.Validations;
using Application.Features.Requests.Command.BookOnShelves;
using MediatR;
using NLog;

namespace Application.Features.Handlers.Command.BookOnShelves
{
    public class UpdateBookOnShelvesCommandHandler : IRequestHandler<UpdateBookOnShelvesCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;

        public UpdateBookOnShelvesCommandHandler(IUnitOfWork unitOfWork, ILogger logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<Unit> Handle(UpdateBookOnShelvesCommand request, CancellationToken cancellationToken)
        {

            var validator = new BookOnShelvesUpdateDtoValidator();
            var validationResult = await validator.ValidateAsync(request.BookOnShelvesUpdateDto, cancellationToken);

            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    _logger.Warn(error.ErrorMessage);
                }
                throw new ArgumentException("Invalid BookOnShelvesUpdateDto provided.");
            }

            var bookOnShelves = await _unitOfWork.BookOnShelves.Get(request.BookOnShelvesUpdateDto.Id);
            if (bookOnShelves == null)
            {
                _logger.Warn($"BookOnShelves with ID {request.BookOnShelvesUpdateDto.Id} not found.");
                throw new KeyNotFoundException($"BookOnShelves with ID {request.BookOnShelvesUpdateDto.Id} not found.");
            }

            _unitOfWork.Mapper.Map(request.BookOnShelvesUpdateDto, bookOnShelves);
            await _unitOfWork.BookOnShelves.Update(bookOnShelves);
            await _unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}
