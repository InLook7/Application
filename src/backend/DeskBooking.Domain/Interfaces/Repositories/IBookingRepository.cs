using DeskBooking.Domain.Entities;

namespace DeskBooking.Domain.Interfaces.Repositories;

public interface IBookingRepository
{
    Task CreateAsync(Booking booking); 
}