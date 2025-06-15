using Microsoft.EntityFrameworkCore;
using DeskBooking.Infrastructure.Persistence.Data;
using DeskBooking.Domain.Entities;
using DeskBooking.Domain.Interfaces.Repositories;

namespace DeskBooking.Infrastructure.Persistence.Repositories;

public class CoworkingRepository : ICoworkingRepository
{
    private readonly ApplicationDbContext _dbContext;

    public CoworkingRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Coworking>> GetAllWithDetailsAsync()
    {
        return await _dbContext.Coworkings
            .Include(c => c.CoworkingPhotos)
            .Include(c => c.Workspaces)
                .ThenInclude(w => w.Bookings)
            .Include(c => c.Workspaces)
                .ThenInclude(w => w.WorkspaceType)
            .ToListAsync();
    }

     public async Task<Coworking?> GetByIdAsync(int coworkingId)
    {
        return await _dbContext.Coworkings
            .FirstOrDefaultAsync(wt => wt.Id == coworkingId);
    }
}