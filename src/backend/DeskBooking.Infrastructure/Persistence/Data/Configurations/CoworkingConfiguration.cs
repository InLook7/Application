using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DeskBooking.Domain.Entities;

namespace DeskBooking.Infrastructure.Persistence.Data.Configurations;

public class CoworkingConfiguration : IEntityTypeConfiguration<Coworking>
{
    public void Configure(EntityTypeBuilder<Coworking> builder)
    {
        builder.HasIndex(c => c.Name)
            .IsUnique();

        builder.Property(c => c.Name)
            .HasMaxLength(50);

        builder.Property(c => c.Description)
           .HasMaxLength(300);
            
        builder.Property(c => c.Address)
            .HasMaxLength(100);
    }
}