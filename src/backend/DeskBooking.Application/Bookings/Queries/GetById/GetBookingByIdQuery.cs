using Mediator;
using FluentResults;
using DeskBooking.Application.Bookings.Dtos;

namespace DeskBooking.Application.Bookings.Queries.GetById;

public record GetBookingByIdQuery(int Id) : IRequest<Result<BookingDto>>;