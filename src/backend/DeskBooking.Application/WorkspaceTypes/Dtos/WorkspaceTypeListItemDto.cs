namespace DeskBooking.Application.WorkspaceTypes.Dtos;

public record WorkspaceTypeListItemDto(
    int Id,
    string Name,
    string? Description,
    List<string> PhotoFilePaths,
    List<string> AmenityFilePaths,
    List<CapacityQuantityGroup> Capacities);