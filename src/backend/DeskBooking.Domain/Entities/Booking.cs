namespace DeskBooking.Domain.Entities;

public class Booking
{
    public int Id { get; set; }

    public string BookedByName { get; set; }

    public string BookedByEmail { get; set; }

    public int WorkspaceId { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    public TimeOnly StartTime { get; set; }

    public TimeOnly EndTime { get; set; }

    // Navigation properties
    public Workspace Workspace { get; set; }
}