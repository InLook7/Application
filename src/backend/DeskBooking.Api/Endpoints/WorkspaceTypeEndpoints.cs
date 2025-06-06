using Mediator;
using DeskBooking.Application.WorkspaceTypes.Queries.GetAll;
using DeskBooking.Application.Workspaces.Queries.GetByWorkspaceType;
using DeskBooking.Api.Extensions;
using DeskBooking.Application.WorkspaceTypes.Queries.GetList;

namespace DeskBooking.Api.Endpoints;

public static class WorkspaceTypeEndpoints
{
    public static void MapWorkspaceTypeEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v1/workspace-types");

        group.MapGet("/", GetWorkspaceTypes);
        group.MapGet("/list", GetWorkspaceTypeList);
        group.MapGet("/{id}/workspaces", GetWorkspacesByWorkspaceTypeId);
    }

    private static async Task<IResult> GetWorkspaceTypes(IMediator mediator)
    {
        var workspaceTypeDtos = await mediator.Send(new GetAllWorkspaceTypesQuery());

        return TypedResults.Ok(workspaceTypeDtos);
    }

    private static async Task<IResult> GetWorkspaceTypeList(IMediator mediator)
    {
        var workspaceTypeListItemDtos = await mediator.Send(new GetWorkspaceTypeListQuery());

        return TypedResults.Ok(workspaceTypeListItemDtos);
    }

    private static async Task<IResult> GetWorkspacesByWorkspaceTypeId(
        int id,
        IMediator mediator)
    {
        var result = await mediator.Send(new GetByWorkspaceTypeIdQuery(id));

        if (result.IsNotFound())
        {
            return TypedResults.NotFound();
        }

        return TypedResults.Ok(result.Value);
    }
}