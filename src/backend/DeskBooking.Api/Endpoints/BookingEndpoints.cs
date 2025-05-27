using Mediator;
using DeskBooking.Api.Requests;
using DeskBooking.Application.Bookings.Commands;
using DeskBooking.Api.Responses;

namespace DeskBooking.Api.Endpoints;

public static class BookingEndpoints
{
    public static void MapBookingEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/bookings");

        group.MapPost("/", CreateBooking);
    }

    private static async Task<IResult> CreateBooking(
        IMediator mediator,
        CreateBookingRequest request)
    {
        var command = new CreateBookingCommand(
            request.UserName,
            request.UserEmail,
            request.WorkspaceId,
            request.StartTime,
            request.EndTime
        );

        var result = await mediator.Send(command);

        if (result.IsFailed)
        {
            var errorResponse = new ErrorResponse(result.Errors.Select(e => e.Message));
            return TypedResults.BadRequest(errorResponse);
        }

        var response = new BookingResponse(result.Value);
        return TypedResults.Created($"api/v1/bookings/{response.Booking.Id}", response);
    }
}