using Mediator;
using DeskBooking.Api.Extensions;
using DeskBooking.Application.Coworkings.Queries.GetList;
using DeskBooking.Application.WorkspaceTypes.Queries.GetList;
using DeskBooking.Application.Workspaces.Queries.Get;

namespace DeskBooking.Api.Endpoints;

public static class CoworkingEndpoints
{
    public static void MapCoworkingEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v1/coworkings");

        group.MapGet("/", GetCoworkingList);
        group.MapGet("/{coworkingId}/workspace-types", GetWorkspaceTypeList);
        group.MapGet("/{coworkingId}/workspace-types/{workspaceTypeId}/workspaces", GetWorkspaces);
    }

    private static async Task<IResult> GetCoworkingList(IMediator mediator)
    {
        var coworkingListItemDtos = await mediator.Send(new GetCoworkingListQuery());

        return TypedResults.Ok(coworkingListItemDtos);
    }

    private static async Task<IResult> GetWorkspaceTypeList(
        int coworkingId,
        IMediator mediator)
    {
        var result = await mediator.Send(new GetWorkspaceTypeListQuery(coworkingId));

        if (result.IsNotFound())
        {
            return TypedResults.NotFound();
        }

        return TypedResults.Ok(result.Value);
    }

    private static async Task<IResult> GetWorkspaces(
        int coworkingId,
        int workspaceTypeId,
        IMediator mediator)
    {
        var result = await mediator.Send(new GetWorkspacesQuery(coworkingId, workspaceTypeId));

        if (result.IsNotFound())
        {
            return TypedResults.NotFound();
        }

        return TypedResults.Ok(result.Value);
    }
}