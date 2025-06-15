namespace DeskBooking.Domain.Entities;

public class CoworkingPhoto
{
    public int Id { get; set; }

    public int CoworkingId { get; set; }

    public string Title { get; set; }

    public string FilePath { get; set; }

    // Navigation properties
    public Coworking Coworking { get; set; }
}