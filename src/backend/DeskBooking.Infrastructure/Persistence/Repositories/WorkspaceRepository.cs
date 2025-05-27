using Microsoft.EntityFrameworkCore;
using DeskBooking.Domain.Entities;
using DeskBooking.Domain.Interfaces.Repositories;
using DeskBooking.Infrastructure.Persistence.Data;

namespace DeskBooking.Infrastructure.Persistence.Repositories;

public class WorkspaceRepository : IWorkspaceRepository
{
    private readonly ApplicationDbContext _dbContext;

    public WorkspaceRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Workspace?> GetByIdAsync(int id)
    {
        return await _dbContext.Workspaces.FirstOrDefaultAsync(w => w.Id == id);
    }
}