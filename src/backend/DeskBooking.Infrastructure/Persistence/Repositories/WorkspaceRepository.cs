using Microsoft.EntityFrameworkCore;
using DeskBooking.Infrastructure.Persistence.Data;
using DeskBooking.Domain.Entities;
using DeskBooking.Domain.Interfaces.Repositories;

namespace DeskBooking.Infrastructure.Persistence.Repositories;

public class WorkspaceRepository : IWorkspaceRepository
{
    private readonly ApplicationDbContext _dbContext;

    public WorkspaceRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Workspace?> GetByIdAsync(int workspaceId)
    {
        return await _dbContext.Workspaces.FirstOrDefaultAsync(w => w.Id == workspaceId);
    }
}