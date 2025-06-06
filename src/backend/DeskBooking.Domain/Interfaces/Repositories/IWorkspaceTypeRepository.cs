using DeskBooking.Domain.Entities;

namespace DeskBooking.Domain.Interfaces.Repositories;

public interface IWorkspaceTypeRepository
{
    Task<IEnumerable<WorkspaceType>> GetAllAsync();

    Task<IEnumerable<WorkspaceType>> GetAllWithDetailsAsync();

    Task<WorkspaceType?> GetByIdAsync(int workspaceTypeId);
}