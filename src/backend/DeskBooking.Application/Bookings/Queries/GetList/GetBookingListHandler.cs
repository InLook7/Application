using Microsoft.Extensions.Logging;
using Mediator;
using DeskBooking.Application.Bookings.Dtos;
using DeskBooking.Application.Bookings.Mappings;
using DeskBooking.Domain.Interfaces;

namespace DeskBooking.Application.Bookings.Queries.GetList;

public class GetBookingListHandler
    : IRequestHandler<GetBookingListQuery, IEnumerable<BookingListItemDto>>
{
    private readonly ILogger<GetBookingListHandler> _logger;
    private readonly IUnitOfWork _unitOfWork;

    public GetBookingListHandler(
        ILogger<GetBookingListHandler> logger,
        IUnitOfWork unitOfWork)
    {
        _logger = logger;
        _unitOfWork = unitOfWork;
    }

    public async ValueTask<IEnumerable<BookingListItemDto>> Handle(GetBookingListQuery query, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Getting booking list.");

        var bookings = await _unitOfWork.BookingRepository.GetAllWithDetailsAsync();

        var bookingListItemDtos = bookings.ToBookingListItemDtos();
        _logger.LogInformation("Successfully fetched {BookingCount} booking list items.", bookings.Count());

        return bookingListItemDtos;
    }
}