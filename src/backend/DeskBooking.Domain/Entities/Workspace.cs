namespace DeskBooking.Domain.Entities;

public class Workspace
{
    public int Id { get; set; }

    public string Name { get; set; }

    public int CoworkingId { get; set; }

    public int WorkspaceTypeId { get; set; }

    public int Capacity { get; set; }

    public int Quantity { get; set; }

    // Navigation properties
    public Coworking Coworking { get; set; }

    public WorkspaceType WorkspaceType { get; set; }

    public ICollection<Booking> Bookings { get; set; }
}