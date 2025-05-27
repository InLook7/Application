namespace DeskBooking.Domain.Entities;

public class WorkspaceTypeAmenity
{
    public int WorkspaceTypeId { get; set; }

    public int AmenityId { get; set; }

    // Navigation properties
    public WorkspaceType WorkspaceType { get; set; }

    public Amenity Amenity { get; set; }
}