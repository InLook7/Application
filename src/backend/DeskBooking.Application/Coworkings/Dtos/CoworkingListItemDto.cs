namespace DeskBooking.Application.Coworkings.Dtos;

public record CoworkingListItemDto(
    int Id,
    string Name,
    string? Description,
    string Address,
    string PhotoFilePath,
    int AvailableDesks,
    int AvailablePrivateRooms,
    int AvailableMeetingRooms);