namespace DeskBooking.Domain.Entities;

public class Workspace
{
    public int Id { get; set; }

    public string Name { get; set; }

    public int WorkspaceTypeId { get; set; }

    public int Capacity { get; set; }

    // Navigation properties
    public WorkspaceType WorkspaceType { get; set; }

    public ICollection<Booking> Bookings { get; set; }
}