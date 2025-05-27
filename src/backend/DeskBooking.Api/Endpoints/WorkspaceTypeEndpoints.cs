using Mediator;
using DeskBooking.Application.WorkspaceTypes.Queries.GetAll;

namespace DeskBooking.Api.Endpoints;

public static class WorkspaceTypeEndpoints
{
    public static void MapWorkspaceTypeEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/workspaceTypes");

        group.MapGet("/", GetWorkspaceTypes);
    }

    private static async Task<IResult> GetWorkspaceTypes(IMediator mediator)
    {
        var workspaceTypes = await mediator.Send(new GetAllWorkspaceTypesQuery());

        return TypedResults.Ok(workspaceTypes);
    }
}