using Mediator;
using DeskBooking.Application.Bookings.Dtos;

namespace DeskBooking.Application.Bookings.Queries.GetList;

public record GetBookingListQuery : IRequest<IEnumerable<BookingListItemDto>>;