using DeskBooking.Domain.Interfaces.Repositories;

namespace DeskBooking.Domain.Interfaces;

public interface IUnitOfWork : IAsyncDisposable
{
    IWorkspaceTypeRepository WorkspaceTypeRepository { get; }

    Task SaveAsync();
}