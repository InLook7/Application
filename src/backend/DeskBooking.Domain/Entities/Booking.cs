namespace DeskBooking.Domain.Entities;

public class Booking
{
    public int Id { get; set; }

    public string UserName { get; set; }

    public string UserEmail { get; set; }

    public int WorkspaceId { get; set; }

    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }

    public DateTime CreatedAt { get; set; }

    // Navigation properties
    public Workspace Workspace { get; set; }
}