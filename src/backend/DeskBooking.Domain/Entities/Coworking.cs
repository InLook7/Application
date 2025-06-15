namespace DeskBooking.Domain.Entities;

public class Coworking
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string? Description { get; set; }

    public string Address { get; set; }

    // Navigation properties
    public virtual ICollection<Workspace> Workspaces { get; set; }

    public virtual ICollection<CoworkingPhoto> CoworkingPhotos { get; set; }
}