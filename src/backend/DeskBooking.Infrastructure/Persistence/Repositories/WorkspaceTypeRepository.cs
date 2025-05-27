using Microsoft.EntityFrameworkCore;
using DeskBooking.Domain.Entities;
using DeskBooking.Domain.Interfaces.Repositories;
using DeskBooking.Infrastructure.Persistence.Data;

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
}