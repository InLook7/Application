using DeskBooking.Domain.Entities;
using DeskBooking.Domain.Interfaces.Repositories;
using DeskBooking.Infrastructure.Persistence.Data;

namespace DeskBooking.Infrastructure.Persistence.Repositories;

public class BookingRepository : IBookingRepository
{
    private readonly ApplicationDbContext _dbContext;

    public BookingRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task CreateAsync(Booking booking)
    {
        await _dbContext.Bookings.AddAsync(booking);
    }
}