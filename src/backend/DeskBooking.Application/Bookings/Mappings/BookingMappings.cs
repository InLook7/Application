using DeskBooking.Application.Bookings.Dtos;
using DeskBooking.Domain.Entities;

namespace DeskBooking.Application.Bookings.Mappings;

public static class BookingMappings
{
    public static BookingDto ToBookingDto(this Booking booking)
    {
        return new BookingDto(
            booking.Id,
            booking.BookedByName,
            booking.BookedByEmail,
            booking.Workspace.CoworkingId,
            booking.WorkspaceId,
            booking.Workspace.WorkspaceTypeId,
            booking.StartDate,
            booking.EndDate,
            booking.StartTime,
            booking.EndTime
        );
    }

    public static IEnumerable<BookingDto> ToBookingDtos(this IEnumerable<Booking> bookings)
    {
        return bookings.Select(ToBookingDto).ToList();
    }

    public static BookingListItemDto ToBookingListItemDto(this Booking booking)
    {
        return new BookingListItemDto(
            booking.Id,
            booking.Workspace.WorkspaceType.Name,
            booking.Workspace.Capacity,
            booking.Workspace.WorkspaceType.WorkspacePhotos.FirstOrDefault().FilePath,
            booking.StartDate,
            booking.EndDate,
            booking.StartTime,
            booking.EndTime
        );
    }

    public static IEnumerable<BookingListItemDto> ToBookingListItemDtos(this IEnumerable<Booking> bookings)
    {
        return bookings.Select(ToBookingListItemDto).ToList();
    }
}