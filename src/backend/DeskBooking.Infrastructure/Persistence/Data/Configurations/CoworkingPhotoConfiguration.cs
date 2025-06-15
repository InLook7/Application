using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DeskBooking.Domain.Entities;

namespace DeskBooking.Infrastructure.Persistence.Data.Configurations;

public class CoworkingPhotoConfiguration : IEntityTypeConfiguration<CoworkingPhoto>
{
    public void Configure(EntityTypeBuilder<CoworkingPhoto> builder)
    {
        builder.Property(cp => cp.Title)
            .HasMaxLength(50);
    }
}