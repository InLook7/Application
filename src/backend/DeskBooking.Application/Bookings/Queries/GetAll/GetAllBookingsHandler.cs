using Microsoft.Extensions.Logging;
using Mediator;
using DeskBooking.Application.Common.Dtos;
using DeskBooking.Application.Common.Mappings;
using DeskBooking.Domain.Interfaces;

namespace DeskBooking.Application.Bookings.Queries.GetAll;

public class GetAllBookingsHandler
    : IRequestHandler<GetAllBookingsQuery, IEnumerable<BookingDto>>
{
    private readonly ILogger<GetAllBookingsHandler> _logger;
    private readonly IUnitOfWork _unitOfWork;

    public GetAllBookingsHandler(
        ILogger<GetAllBookingsHandler> logger,
        IUnitOfWork unitOfWork)
    {
        _logger = logger;
        _unitOfWork = unitOfWork;
    }

    public async ValueTask<IEnumerable<BookingDto>> Handle(GetAllBookingsQuery query, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Getting all bookings.");

        var bookings = await _unitOfWork.BookingRepository.GetAllAsync();

        var bookingDtos = bookings.ToBookingDtos();
        _logger.LogInformation("Successfully fetched {BookingCount} booking.", bookings.Count());

        return bookingDtos;
    }
}