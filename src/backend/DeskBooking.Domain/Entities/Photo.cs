namespace DeskBooking.Domain.Entities;

public class Photo
{
    public int Id { get; set; }

    public int WorkspaceTypeId { get; set; }

    public string Caption { get; set; }

    public string FileUrl { get; set; }

    // Navigation properties
    public WorkspaceType WorkspaceType { get; set; }
}