namespace DeskBooking.Domain.Entities;

public class Booking
{
    public int Id { get; set; }

    public string UserName { get; set; }

    public string UserEmail { get; set; }

    public int WorkspaceId { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    public TimeOnly StartTime { get; set; }

    public TimeOnly EndTime { get; set; }

    public DateTime CreatedAt { get; set; }

    // Navigation properties
    public Workspace Workspace { get; set; }
}