using Microsoft.EntityFrameworkCore;
using DeskBooking.Infrastructure.Persistence.Data;
using DeskBooking.Domain.Entities;
using DeskBooking.Domain.Interfaces.Repositories;

namespace DeskBooking.Infrastructure.Persistence.Repositories;

public class BookingRepository : IBookingRepository
{
    private readonly ApplicationDbContext _dbContext;

    public BookingRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Booking>> GetAllWithDetailsAsync()
    {
        return await _dbContext.Bookings
            .Include(b => b.Workspace)
                .ThenInclude(w => w.WorkspaceType)
                    .ThenInclude(wt => wt.WorkspacePhotos)
            .OrderByDescending(b => b.Id)
            .ToListAsync();
    }

    public async Task<Booking?> GetByIdAsync(int bookingId)
    {
        return await _dbContext.Bookings
            .Include(b => b.Workspace)
            .FirstOrDefaultAsync(w => w.Id == bookingId);
    }

    public async Task<IEnumerable<Booking>> GetOverlappingBookingsAsync(int workspaceId,
        DateOnly startDate, DateOnly endDate, TimeOnly startTime, TimeOnly endTime)
    {
        return await _dbContext.Bookings
            .Where(b => b.WorkspaceId == workspaceId &&
                b.StartDate <= endDate &&
                b.EndDate >= startDate &&
                b.StartTime < endTime &&
                b.EndTime > startTime)
            .ToListAsync();
    }

    public async Task CreateAsync(Booking booking)
    {
        await _dbContext.Bookings.AddAsync(booking);
    }

    public void Update(Booking booking)
    {
        _dbContext.Bookings.Update(booking);
    }

    public async Task<bool> DeleteByIdAsync(int bookingId)
    {
        var deleteCount = await _dbContext.Bookings
            .Where(b => b.Id == bookingId)
            .ExecuteDeleteAsync();

        return deleteCount > 0;
    }
}