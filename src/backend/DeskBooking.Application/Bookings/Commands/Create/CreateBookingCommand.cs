using Mediator;
using FluentResults;
using DeskBooking.Application.Bookings.Dtos;

namespace DeskBooking.Application.Bookings.Commands.Create;

public record CreateBookingCommand(
    string BookedByName,
    string BookedByEmail,
    int WorkspaceId,
    DateOnly StartDate,
    DateOnly EndDate,
    TimeOnly StartTime,
    TimeOnly EndTime) : IRequest<Result<BookingDto>>;