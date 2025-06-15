using Mediator;
using DeskBooking.Api.Requests;
using DeskBooking.Application.Assistants.Queries.AskBookingAssistant;
using DeskBooking.Api.Responses;

namespace DeskBooking.Api.Endpoints;

public static class AssistantEndpoints
{
    public static void MapAssistantEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v1/assistant");

        group.MapPost("/", AskBookingAssistant);
    }

    private static async Task<IResult> AskBookingAssistant(
        AskBookingAssistantRequest request,
        IMediator mediator)
    {
        var response = await mediator.Send(new AskBookingAssistantQuery(request.Question));

        return TypedResults.Ok(new AskBookingAssistantResponse(response));
    }
}