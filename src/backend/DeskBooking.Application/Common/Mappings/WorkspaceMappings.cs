using DeskBooking.Application.Common.Dtos;
using DeskBooking.Domain.Entities;

namespace DeskBooking.Application.Common.Mappings;

public static class WorkspaceMappings
{
    public static WorkspaceTypeDto ToWorkspaceTypeDto(this WorkspaceType workspaceType)
    {
        return new WorkspaceTypeDto
        {
            Id = workspaceType.Id,
            Name = workspaceType.Name,
            Description = workspaceType.Description
        };
    }

    public static IEnumerable<WorkspaceTypeDto> ToWorkspaceTypeDtos(this IEnumerable<WorkspaceType> workspaceTypes)
    {
        return workspaceTypes.Select(ToWorkspaceTypeDto).ToList();
    }
}