using Microsoft.Extensions.Logging;
using Mediator;
using FluentResults;
using DeskBooking.Application.Bookings.Dtos;
using DeskBooking.Application.Bookings.Mappings;
using DeskBooking.Application.Common.Errors;
using DeskBooking.Domain.Interfaces;

namespace DeskBooking.Application.Bookings.Queries.GetById;

public class GetBookingByIdHandler
    : IRequestHandler<GetBookingByIdQuery, Result<BookingDto>>
{
    private readonly ILogger<GetBookingByIdHandler> _logger;
    private readonly IUnitOfWork _unitOfWork;

    public GetBookingByIdHandler(
        ILogger<GetBookingByIdHandler> logger,
        IUnitOfWork unitOfWork)
    {
        _logger = logger;
        _unitOfWork = unitOfWork;
    }

    public async ValueTask<Result<BookingDto>> Handle(GetBookingByIdQuery query, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Getting booking with ID {BookingId}", query.Id);

        var booking = await _unitOfWork.BookingRepository.GetByIdAsync(query.Id);
        if (booking == null)
        {
            _logger.LogWarning("Booking with ID {BookingId} does not exist.", query.Id);
            return Result.Fail(new NotFoundError());
        }

        var bookingDto = booking.ToBookingDto();
        _logger.LogInformation("Successfully fetched booking with ID {BookingId}.", query.Id);

        return Result.Ok(bookingDto);
    }
}