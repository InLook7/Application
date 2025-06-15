namespace DeskBooking.Application.Bookings.Dtos;

public record BookingDto(
    int Id,
    string BookedByName,
    string BookedByEmail,
    int CoworkingId,
    int WorkspaceId,
    int WorkspaceTypeId,
    DateOnly StartDate,
    DateOnly EndDate,
    TimeOnly StartTime,
    TimeOnly EndTime);