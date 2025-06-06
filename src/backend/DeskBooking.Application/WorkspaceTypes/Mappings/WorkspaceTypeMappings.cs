using DeskBooking.Application.WorkspaceTypes.Dtos;
using DeskBooking.Domain.Entities;

namespace DeskBooking.Application.WorkspaceTypes.Mappings;

public static class WorkspaceTypeMappings
{
    public static WorkspaceTypeDto ToWorkspaceTypeDto(this WorkspaceType workspaceType)
    {
        return new WorkspaceTypeDto(
            workspaceType.Id,
            workspaceType.Name,
            workspaceType.Description
        );
    }

    public static IEnumerable<WorkspaceTypeDto> ToWorkspaceTypeDtos(this IEnumerable<WorkspaceType> workspaceTypes)
    {
        return workspaceTypes.Select(ToWorkspaceTypeDto).ToList();
    }
}