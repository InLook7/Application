using Mediator;
using FluentResults;
using DeskBooking.Application.Common.Dtos;

namespace DeskBooking.Application.Bookings.Commands.Patch;

public record PatchBookingCommand(
    int Id,
    int? WorkspaceId,
    DateTime? StartTime,
    DateTime? EndTime) : IRequest<Result<BookingDto>>;