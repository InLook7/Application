using DeskBooking.Domain.Interfaces;
using DeskBooking.Domain.Interfaces.Repositories;
using DeskBooking.Infrastructure.Persistence.Data;
using DeskBooking.Infrastructure.Persistence.Repositories;

namespace DeskBooking.Infrastructure.Persistence;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _dbContext;

    public UnitOfWork(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IWorkspaceTypeRepository WorkspaceTypeRepository
        => new WorkspaceTypeRepository(_dbContext);

    public IWorkspaceRepository WorkspaceRepository
        => new WorkspaceRepository(_dbContext);

    public IBookingRepository BookingRepository
        => new BookingRepository(_dbContext);

    public async Task SaveAsync()
    {
        await _dbContext.SaveChangesAsync();
    }

    public async ValueTask DisposeAsync()
    {
        await _dbContext.DisposeAsync();
    }
}