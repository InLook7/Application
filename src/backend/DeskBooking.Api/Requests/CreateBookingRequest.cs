namespace DeskBooking.Api.Requests;

public record CreateBookingRequest(
    string UserName,
    string UserEmail,
    int WorkspaceId,
    DateOnly StartDate,
    DateOnly EndDate,
    TimeOnly StartTime,
    TimeOnly EndTime);