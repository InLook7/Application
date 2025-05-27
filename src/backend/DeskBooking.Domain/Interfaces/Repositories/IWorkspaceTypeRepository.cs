using DeskBooking.Domain.Entities;

namespace DeskBooking.Domain.Interfaces.Repositories;

public interface IWorkspaceTypeRepository
{
    Task<IEnumerable<WorkspaceType>> GetAllAsync();
}