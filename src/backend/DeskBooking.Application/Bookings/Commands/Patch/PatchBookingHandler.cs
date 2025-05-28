using Microsoft.Extensions.Logging;
using Mediator;
using FluentResults;
using DeskBooking.Application.Common.Dtos;
using DeskBooking.Application.Common.Errors;
using DeskBooking.Application.Common.Mappings;
using DeskBooking.Domain.Interfaces;

namespace DeskBooking.Application.Bookings.Commands.Patch;

public class PatchBookingHandler
    : IRequestHandler<PatchBookingCommand, Result<BookingDto>>
{
    private readonly ILogger<PatchBookingHandler> _logger;
    private readonly IUnitOfWork _unitOfWork;

    public PatchBookingHandler(
        ILogger<PatchBookingHandler> logger,
        IUnitOfWork unitOfWork)
    {
        _logger = logger;
        _unitOfWork = unitOfWork;
    }

    public async ValueTask<Result<BookingDto>> Handle(PatchBookingCommand command, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Patching a booking with ID {BookingId}.", command.Id);

        var booking = await _unitOfWork.BookingRepository.GetByIdAsync(command.Id);
        if (booking == null)
        {
            _logger.LogWarning("Booking with ID {BookingId} does not exist.", command.Id);
            return Result.Fail(new NotFoundError());
        }

        if (command.WorkspaceId is int workspaceId)
        {
            var workspace = await _unitOfWork.WorkspaceRepository.GetByIdAsync(workspaceId);
            if (workspace == null)
            {
                _logger.LogWarning("Workspace with ID {WorkspaceId} does not exist.", workspaceId);
                return Result.Fail(new ValidationError($"Workspace with ID {workspaceId} was not found."));
            }
        }

        if (command.StartTime is DateTime startTime)
        {
            booking.StartTime = startTime;
        }

        if (command.EndTime is DateTime endTime)
        {
            booking.EndTime = endTime;
        }

        _unitOfWork.BookingRepository.Update(booking);
        await _unitOfWork.SaveAsync();

        var bookingDto = booking.ToBookingDto();
        _logger.LogInformation("Booking with ID {BookingId} has been patched.", bookingDto.Id);

        return Result.Ok(bookingDto);
    }
}