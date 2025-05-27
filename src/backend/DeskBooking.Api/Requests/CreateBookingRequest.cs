namespace DeskBooking.Api.Requests;

public record CreateBookingRequest(
    string UserName,
    string UserEmail,
    int WorkspaceId,
    DateTime StartTime,
    DateTime EndTime);