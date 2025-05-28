using DeskBooking.Domain.Entities;

namespace DeskBooking.Domain.Interfaces.Repositories;

public interface IBookingRepository
{
    Task<IEnumerable<Booking>> GetAllAsync();

    Task<Booking?> GetByIdAsync(int bookingId);

    Task CreateAsync(Booking booking); 

    void Update(Booking booking); 

    Task<bool> DeleteByIdAsync(int bookingId);
}