using Mediator;
using FluentResults;
using DeskBooking.Domain.Interfaces;
using DeskBooking.Domain.Entities;
using DeskBooking.Application.Common.Dtos;
using DeskBooking.Application.Common.Mappings;
using Microsoft.Extensions.Logging;

namespace DeskBooking.Application.Bookings.Commands.Create;

public class CreateBookingHandler
    : IRequestHandler<CreateBookingCommand, Result<BookingDto>>
{
    private readonly ILogger<CreateBookingHandler> _logger;
    private readonly IUnitOfWork _unitOfWork;

    public CreateBookingHandler(
        ILogger<CreateBookingHandler> logger,
        IUnitOfWork unitOfWork)
    {
        _logger = logger;
        _unitOfWork = unitOfWork;
    }

    public async ValueTask<Result<BookingDto>> Handle(CreateBookingCommand command, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Creating a new booking by user {UserEmail}.", command.UserEmail);

        var workspace = await _unitOfWork.WorkspaceRepository.GetByIdAsync(command.WorkspaceId);
        if (workspace == null)
        {
            _logger.LogWarning("Workspace with ID {WorkspaceId} does not exist.", command.WorkspaceId);
            return Result.Fail($"Workspace with ID {command.WorkspaceId} was not found.");
        }

        var booking = new Booking
        {
            UserName = command.UserName,
            UserEmail = command.UserEmail,
            WorkspaceId = command.WorkspaceId,
            StartTime = command.StartTime,
            EndTime = command.EndTime,
            CreatedAt = DateTime.UtcNow,
        };

        await _unitOfWork.BookingRepository.CreateAsync(booking);
        await _unitOfWork.SaveAsync();

        var bookingDto = booking.ToBookingDto();
        _logger.LogInformation("Successfully created booking with ID {BookingId}.", bookingDto.Id);

        return Result.Ok(bookingDto);
    }
}