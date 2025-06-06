namespace DeskBooking.Application.Workspaces.Dtos;

public record WorkspaceDto(
    int Id,
    string Name,
    int WorkspaceTypeId,
    int Capacity,
    int Quantity);