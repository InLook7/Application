namespace DeskBooking.Api.Requests;

public record PatchBookingRequest(
    int WorkspaceId,
    DateOnly StartDate,
    DateOnly EndDate,
    TimeOnly StartTime,
    TimeOnly EndTime);