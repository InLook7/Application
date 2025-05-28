using Microsoft.EntityFrameworkCore;
using DeskBooking.Infrastructure.Persistence.Data.Configurations;
using DeskBooking.Domain.Entities;

namespace DeskBooking.Infrastructure.Persistence.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<WorkspaceType> WorkspaceTypes { get; set; }

    public DbSet<Photo> Photos { get; set; }

    public DbSet<Amenity> Amenities { get; set; }

    public DbSet<WorkspaceTypeAmenity> WorkspaceTypeAmenities { get; set; }

    public DbSet<Workspace> Workspaces { get; set; }

    public DbSet<Booking> Bookings { get; set; }

    public ApplicationDbContext(DbContextOptions options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new WorkspaceTypeConfiguration());
        modelBuilder.ApplyConfiguration(new PhotoConfiguration());
        modelBuilder.ApplyConfiguration(new AmenityConfiguration());
        modelBuilder.ApplyConfiguration(new WorkspaceTypeAmenityConfiguration());
        modelBuilder.ApplyConfiguration(new WorkspaceConfiguration());
        modelBuilder.ApplyConfiguration(new BookingConfiguration());

        base.OnModelCreating(modelBuilder);
    }
}