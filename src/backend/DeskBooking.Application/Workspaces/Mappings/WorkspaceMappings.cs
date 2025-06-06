using DeskBooking.Application.Workspaces.Dtos;
using DeskBooking.Domain.Entities;

namespace DeskBooking.Application.Workspaces.Mappings;

public static class WorkspaceMappings
{
    public static WorkspaceDto ToWorkspaceDto(this Workspace workspace)
    {
        return new WorkspaceDto(
            workspace.Id,
            workspace.Name,
            workspace.WorkspaceTypeId,
            workspace.Capacity,
            workspace.Quantity
        );
    }

    public static IEnumerable<WorkspaceDto> ToWorkspaceDtos(this IEnumerable<Workspace> workspaces)
    {
        return workspaces.Select(ToWorkspaceDto).ToList();
    }
}