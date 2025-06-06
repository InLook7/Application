using DeskBooking.Domain.Entities;

namespace DeskBooking.Domain.Interfaces.Repositories;

public interface IBookingRepository
{
    Task<IEnumerable<Booking>> GetAllWithDetailsAsync();

    Task<Booking?> GetByIdAsync(int bookingId);

    Task<IEnumerable<Booking>> GetOverlappingBookingsAsync(int workspaceId,
        DateOnly startDate, DateOnly endDate, TimeOnly startTime, TimeOnly endTime);

    Task CreateAsync(Booking booking); 

    void Update(Booking booking); 

    Task<bool> DeleteByIdAsync(int bookingId);
}