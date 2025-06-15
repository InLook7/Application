using DeskBooking.Domain.Entities;

namespace DeskBooking.Domain.Interfaces.Repositories;

public interface ICoworkingRepository
{
    Task<IEnumerable<Coworking>> GetAllWithDetailsAsync();

    Task<Coworking?> GetByIdAsync(int coworkingId);
}