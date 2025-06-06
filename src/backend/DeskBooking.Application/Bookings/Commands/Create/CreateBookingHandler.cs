using Microsoft.Extensions.Logging;
using Mediator;
using FluentResults;
using FluentValidation;
using DeskBooking.Application.Bookings.Dtos;
using DeskBooking.Application.Bookings.Mappings;
using DeskBooking.Application.Common.Errors;
using DeskBooking.Domain.Entities;
using DeskBooking.Domain.Interfaces;

namespace DeskBooking.Application.Bookings.Commands.Create;

public class CreateBookingHandler
    : IRequestHandler<CreateBookingCommand, Result<BookingDto>>
{
    private readonly ILogger<CreateBookingHandler> _logger;
    private readonly IValidator<CreateBookingCommand> _validator;
    private readonly IUnitOfWork _unitOfWork;

    public CreateBookingHandler(
        ILogger<CreateBookingHandler> logger,
        IValidator<CreateBookingCommand> validator,
        IUnitOfWork unitOfWork)
    {
        _logger = logger;
        _validator = validator;
        _unitOfWork = unitOfWork;
    }

    public async ValueTask<Result<BookingDto>> Handle(CreateBookingCommand command, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Creating a new booking by {BookedByEmail}.", command.BookedByEmail);

        var validationResult = await _validator.ValidateAsync(command, cancellationToken);
        if (!validationResult.IsValid)
        {
            _logger.LogWarning("Input validation failed: {Errors}", validationResult.Errors.Select(e => e.ErrorMessage));
            return Result.Fail(validationResult.Errors.Select(e => new ValidationError(e.ErrorMessage)));
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
        if (overlappingBookings.Count() >= workspace.Quantity)
        {
            _logger.LogWarning("No availability for workspace ID {WorkspaceId} during the requested period.", command.WorkspaceId);
            return Result.Fail(new ValidationError("Selected time is not available."));
        }

        var booking = new Booking
        {
            BookedByName = command.BookedByName,
            BookedByEmail = command.BookedByEmail,
            WorkspaceId = command.WorkspaceId,
            StartDate = command.StartDate,
            EndDate = command.EndDate,
            StartTime = command.StartTime,
            EndTime = command.EndTime
        };

        await _unitOfWork.BookingRepository.CreateAsync(booking);
        await _unitOfWork.SaveAsync();

        var bookingDto = booking.ToBookingDto();
        _logger.LogInformation("Successfully created booking with ID {BookingId}.", bookingDto.Id);

        return Result.Ok(bookingDto);
    }
}