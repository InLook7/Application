using Mediator;
using FluentResults;
using DeskBooking.Application.Common.Dtos;

namespace DeskBooking.Application.Bookings.Queries.GetById;

public record GetBookingByIdQuery(int Id) : IRequest<Result<BookingDto>>;