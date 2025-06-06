namespace DeskBooking.Domain.Entities;

public class Amenity
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string FilePath { get; set; }

    // Navigation properties
    public virtual ICollection<WorkspaceTypeAmenity> WorkspaceTypeAmenities { get; set; }
}