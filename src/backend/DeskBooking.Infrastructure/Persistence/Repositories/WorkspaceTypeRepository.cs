using Microsoft.EntityFrameworkCore;
using DeskBooking.Infrastructure.Persistence.Data;
using DeskBooking.Domain.Entities;
using DeskBooking.Domain.Interfaces.Repositories;

namespace DeskBooking.Infrastructure.Persistence.Repositories;

public class WorkspaceTypeRepository : IWorkspaceTypeRepository
{
    private readonly ApplicationDbContext _dbContext;

    public WorkspaceTypeRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<WorkspaceType>> GetAllAsync()
    {
        return await _dbContext.WorkspaceTypes.ToListAsync();
    }

    public async Task<IEnumerable<WorkspaceType>> GetAllWithDetailsAsync()
    {
        return await _dbContext.WorkspaceTypes
            .Include(wt => wt.WorkspacePhotos)
            .Include(wt => wt.WorkspaceTypeAmenities)
                .ThenInclude(wta => wta.Amenity)
            .Include(wt => wt.Workspaces)
                .ThenInclude(w => w.Bookings)
            .ToListAsync();
    }

    public async Task<WorkspaceType?> GetByIdAsync(int workspaceTypeId)
    {
        return await _dbContext.WorkspaceTypes
            .FirstOrDefaultAsync(wt => wt.Id == workspaceTypeId);
    }
}