using Mediator;
using DeskBooking.Application.Common.Dtos;

namespace DeskBooking.Application.Bookings.Queries.GetAll;

public record GetAllBookingsQuery : IRequest<IEnumerable<BookingDto>>;