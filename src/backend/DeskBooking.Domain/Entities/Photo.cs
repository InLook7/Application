namespace DeskBooking.Domain.Entities;

public class Photo
{
    public int Id { get; set; }

    public int WorkspaceTypeId { get; set; }

    public string Title { get; set; }

    public string FilePath { get; set; }

    // Navigation properties
    public WorkspaceType WorkspaceType { get; set; }
}