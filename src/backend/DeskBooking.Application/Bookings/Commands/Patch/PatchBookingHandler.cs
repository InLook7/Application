using Microsoft.Extensions.Logging;
using Mediator;
using FluentResults;
using DeskBooking.Application.Bookings.Dtos;
using DeskBooking.Application.Bookings.Mappings;
using DeskBooking.Application.Common.Errors;
using DeskBooking.Domain.Interfaces;
using FluentValidation;

namespace DeskBooking.Application.Bookings.Commands.Patch;

public class PatchBookingHandler
    : IRequestHandler<PatchBookingCommand, Result<BookingDto>>
{
    private readonly ILogger<PatchBookingHandler> _logger;
    private readonly IValidator<PatchBookingCommand> _validator;
    private readonly IUnitOfWork _unitOfWork;

    public PatchBookingHandler(
        ILogger<PatchBookingHandler> logger,
        IValidator<PatchBookingCommand> validator,
        IUnitOfWork unitOfWork)
    {
        _logger = logger;
        _validator = validator;
        _unitOfWork = unitOfWork;
    }

    public async ValueTask<Result<BookingDto>> Handle(PatchBookingCommand command, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Patching a booking with ID {BookingId}.", command.Id);

        var validationResult = await _validator.ValidateAsync(command, cancellationToken);
        if (!validationResult.IsValid)
        {
            _logger.LogWarning("Input validation failed: {Errors}", validationResult.Errors.Select(e => e.ErrorMessage));
            return Result.Fail(validationResult.Errors.Select(e => new ValidationError(e.ErrorMessage)));
        }

        var booking = await _unitOfWork.BookingRepository.GetByIdAsync(command.Id);
        if (booking == null)
        {
            _logger.LogWarning("Booking with ID {BookingId} does not exist.", command.Id);
            return Result.Fail(new NotFoundError());
        }

        var workspace = await _unitOfWork.WorkspaceRepository.GetByIdAsync(command.WorkspaceId);
        if (workspace == null)
        {
            _logger.LogWarning("Workspace with ID {WorkspaceId} does not exist.", command.WorkspaceId);
            return Result.Fail(new ValidationError($"Workspace with ID {command.WorkspaceId} was not found."));
        }

        var bookingDurationDays = command.EndDate.DayNumber - command.StartDate.DayNumber + 1;
        if (workspace.WorkspaceType.Name == "Meeting Room" && bookingDurationDays > 1)
        {
            _logger.LogWarning("Booking duration {Duration} days exceeds maximum allowed (1 day).", bookingDurationDays);
            return Result.Fail(new ValidationError("Meeting Room bookings cannot exceed 1 day."));
        }
        if (bookingDurationDays > 30)
        {
            _logger.LogWarning("Booking duration {Duration} days exceeds maximum allowed (30 days).", bookingDurationDays);
            return Result.Fail(new ValidationError("Bookings cannot exceed 30 days."));
        }

        var overlappingBookings = await _unitOfWork.BookingRepository.GetOverlappingBookingsAsync(command.WorkspaceId,
            command.StartDate, command.EndDate, command.StartTime, command.EndTime);
        if (overlappingBookings.Count(ob => ob.Id != booking.Id) >= workspace.Quantity)
        {
            _logger.LogWarning("No availability for workspace ID {WorkspaceId} during the requested period.", command.WorkspaceId);
            return Result.Fail(new ValidationError("Selected time is not available."));
        }

        booking.WorkspaceId = command.WorkspaceId;
        booking.StartDate = command.StartDate;
        booking.EndDate = command.EndDate;
        booking.StartTime = command.StartTime;
        booking.EndTime = command.EndTime;

        _unitOfWork.BookingRepository.Update(booking);
        await _unitOfWork.SaveAsync();

        var bookingDto = booking.ToBookingDto();
        _logger.LogInformation("Booking with ID {BookingId} has been patched.", bookingDto.Id);

        return Result.Ok(bookingDto);
    }
}