using DeskBooking.Domain.Entities;

namespace DeskBooking.Domain.Interfaces.Repositories;

public interface IWorkspaceRepository
{
    Task<Workspace?> GetByIdAsync(int workspaceId);

    Task<IEnumerable<Workspace>> GetByWorkspaceTypeId(int workspaceTypeId);
}