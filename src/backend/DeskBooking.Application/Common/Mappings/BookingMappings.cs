using DeskBooking.Application.Common.Dtos;
using DeskBooking.Domain.Entities;

namespace DeskBooking.Application.Common.Mappings;

public static class BookingMappings
{
    public static BookingDto ToBookingDto(this Booking booking)
    {
        return new BookingDto(
            booking.Id,
            booking.UserName,
            booking.UserEmail,
            booking.WorkspaceId,
            booking.StartTime,
            booking.EndTime,
            booking.CreatedAt
        );
    }

    public static IEnumerable<BookingDto> ToBookingDtos(this IEnumerable<Booking> bookings)
    {
        return bookings.Select(ToBookingDto).ToList();
    }
}