namespace DeskBooking.Application.Common.Dtos;

public record BookingDto(
    int Id,
    string UserName,
    string UserEmail,
    int WorkspaceId,
    DateTime StartTime,
    DateTime EndTime,
    DateTime CreatedAt);