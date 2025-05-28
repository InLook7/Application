using Microsoft.Extensions.Logging;
using Mediator;
using DeskBooking.Domain.Interfaces;

namespace DeskBooking.Application.Bookings.Commands.Delete;

public class DeleteBookingByIdHandler
    : IRequestHandler<DeleteBookingByIdCommand, bool>
{
    private readonly ILogger<DeleteBookingByIdHandler> _logger;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteBookingByIdHandler(
        ILogger<DeleteBookingByIdHandler> logger,
        IUnitOfWork unitOfWork)
    {
        _logger = logger;
        _unitOfWork = unitOfWork;
    }

    public async ValueTask<bool> Handle(DeleteBookingByIdCommand command, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Deleting a booking with ID {BookingId}.", command.Id);

        var isDeleted = await _unitOfWork.BookingRepository.DeleteByIdAsync(command.Id);

        if (isDeleted)
        {
            _logger.LogInformation("Booking with ID {BookingId} has been deleted.", command.Id);
        }
        else
        {
            _logger.LogWarning("Booking with ID {BookingId} was not found.", command.Id);
        }

        return isDeleted;
    }
}