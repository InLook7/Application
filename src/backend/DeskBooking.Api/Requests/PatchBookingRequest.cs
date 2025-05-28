namespace DeskBooking.Api.Requests;

public record PatchBookingRequest(
    int? WorkspaceId,
    DateTime? StartTime,
    DateTime? EndTime);