using Mediator;
using FluentResults;
using DeskBooking.Application.Common.Dtos;

namespace DeskBooking.Application.Bookings.Commands.Patch;

public record PatchBookingCommand(
    int Id,
    int? WorkspaceId,
    DateOnly? StartDate,
    DateOnly? EndDate,
    TimeOnly? StartTime,
    TimeOnly? EndTime) : IRequest<Result<BookingDto>>;