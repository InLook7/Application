namespace DeskBooking.Api.Responses;

public record ErrorResponse(IEnumerable<string> Errors);