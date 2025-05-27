using Mediator;
using FluentResults;
using DeskBooking.Application.Common.Dtos;

namespace DeskBooking.Application.Bookings.Commands;

public record CreateBookingCommand(
    string UserName,
    string UserEmail,
    int WorkspaceId,
    DateTime StartTime,
    DateTime EndTime) : IRequest<Result<BookingDto>>;