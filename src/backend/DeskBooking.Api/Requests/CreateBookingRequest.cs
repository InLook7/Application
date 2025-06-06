namespace DeskBooking.Api.Requests;

public record CreateBookingRequest(
    string BookedByName,
    string BookedByEmail,
    int WorkspaceId,
    DateOnly StartDate,
    DateOnly EndDate,
    TimeOnly StartTime,
    TimeOnly EndTime);