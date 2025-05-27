using Mediator;
using FluentResults;
using DeskBooking.Domain.Interfaces;
using DeskBooking.Domain.Entities;
using DeskBooking.Application.Common.Dtos;
using DeskBooking.Application.Common.Mappings;

namespace DeskBooking.Application.Bookings.Commands;

public class CreateBookingHandler
    : IRequestHandler<CreateBookingCommand, Result<BookingDto>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateBookingHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async ValueTask<Result<BookingDto>> Handle(CreateBookingCommand command, CancellationToken cancellationToken)
    {
        var workspace = await _unitOfWork.WorkspaceRepository.GetByIdAsync(command.WorkspaceId);
        if (workspace == null)
        {
            return Result.Fail($"Workspace {command.WorkspaceId} was not found.");
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
        return Result.Ok(bookingDto);
    }
}