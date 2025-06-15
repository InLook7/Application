using Mediator;
using DeskBooking.Application.WorkspaceTypes.Queries.GetAll;

namespace DeskBooking.Api.Endpoints;

public static class WorkspaceTypeEndpoints
{
    public static void MapWorkspaceTypeEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v1/workspace-types");

        group.MapGet("/", GetWorkspaceTypes);
    }

    private static async Task<IResult> GetWorkspaceTypes(IMediator mediator)
    {
        var workspaceTypeDtos = await mediator.Send(new GetAllWorkspaceTypesQuery());

        return TypedResults.Ok(workspaceTypeDtos);
    }
}