namespace DeskBooking.Domain.Entities;

public class WorkspaceType
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string? Description { get; set; }

    // Navigation properties
    public virtual ICollection<Workspace> Workspaces { get; set; }

    public virtual ICollection<Photo> Photos { get; set; }

    public virtual ICollection<WorkspaceTypeAmenity> WorkspaceTypeAmenities { get; set; }
}