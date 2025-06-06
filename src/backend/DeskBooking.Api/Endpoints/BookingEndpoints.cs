using Mediator;
using DeskBooking.Api.Requests;
using DeskBooking.Api.Extensions;
using DeskBooking.Application.Bookings.Commands.Create;
using DeskBooking.Application.Bookings.Commands.Delete;
using DeskBooking.Application.Bookings.Commands.Patch;
using DeskBooking.Application.Bookings.Queries.GetList;
using DeskBooking.Application.Bookings.Queries.GetById;

namespace DeskBooking.Api.Endpoints;

public static class BookingEndpoints
{
    public static void MapBookingEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v1/bookings");

        group.MapGet("/", GetBookingList);
        group.MapGet("/{id}", GetBookingById);
        group.MapPost("/", CreateBooking);
        group.MapPatch("/{id}", PatchBooking);
        group.MapDelete("/{id}", DeleteBookingById);
    }

    private static async Task<IResult> GetBookingList(IMediator mediator)
    {
        var bookingListItemDtos = await mediator.Send(new GetBookingListQuery());

        return TypedResults.Ok(bookingListItemDtos);
    }

    private static async Task<IResult> GetBookingById(
        int id,
        IMediator mediator)
    {
        var result = await mediator.Send(new GetBookingByIdQuery(id));

        if (result.IsNotFound())
        {
            return TypedResults.NotFound();
        }

        return TypedResults.Ok(result.Value);
    }

    private static async Task<IResult> CreateBooking(
        CreateBookingRequest request,
        IMediator mediator)
    {
        var command = new CreateBookingCommand(
            request.BookedByName,
            request.BookedByEmail,
            request.WorkspaceId,
            request.StartDate,
            request.EndDate,
            request.StartTime,
            request.EndTime
        );

        var result = await mediator.Send(command);


        if (result.IsValidationError())
        {
            return TypedResults.BadRequest(result.ToErrorResponse());
        }

        return TypedResults.Created($"api/v1/bookings/{result.Value.Id}", result.Value);
    }

    private static async Task<IResult> PatchBooking(
        int id,
        PatchBookingRequest request,
        IMediator mediator)
    {
        var command = new PatchBookingCommand(
            id,
            request.WorkspaceId,
            request.StartDate,
            request.EndDate,
            request.StartTime,
            request.EndTime
        );

        var result = await mediator.Send(command);

        if (result.IsNotFound())
        {
            return TypedResults.NotFound();
        }

        if (result.IsValidationError())
        {
            return TypedResults.BadRequest(result.ToErrorResponse());
        }

        return TypedResults.Ok(result.Value);
    }

    private static async Task<IResult> DeleteBookingById(
        int id,
        IMediator mediator)
    {
        var isDeleted = await mediator.Send(new DeleteBookingByIdCommand(id));

        if (!isDeleted)
        {
            return TypedResults.NotFound();
        }

        return TypedResults.NoContent();
    }
}