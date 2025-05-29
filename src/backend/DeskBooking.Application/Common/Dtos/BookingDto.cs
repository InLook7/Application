namespace DeskBooking.Application.Common.Dtos;

public record BookingDto(
    int Id,
    string UserName,
    string UserEmail,
    int WorkspaceId,
    DateOnly StartDate,
    DateOnly EndDate,
    TimeOnly StartTime,
    TimeOnly EndTime,
    DateTime CreatedAt);