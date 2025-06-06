namespace DeskBooking.Application.Bookings.Dtos;

public record BookingListItemDto(
    int Id,
    string WorkspaceTypeName,
    int WorkspaceCapacity,
    string PhotoFilePath,
    DateOnly StartDate,
    DateOnly EndDate,
    TimeOnly StartTime,
    TimeOnly EndTime);