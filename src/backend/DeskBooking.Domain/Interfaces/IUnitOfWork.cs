using DeskBooking.Domain.Interfaces.Repositories;

namespace DeskBooking.Domain.Interfaces;

public interface IUnitOfWork : IAsyncDisposable
{
    ICoworkingRepository CoworkingRepository { get; }

    IWorkspaceTypeRepository WorkspaceTypeRepository { get; }

    IWorkspaceRepository WorkspaceRepository { get; }

    IBookingRepository BookingRepository { get; }

    Task SaveAsync();
}