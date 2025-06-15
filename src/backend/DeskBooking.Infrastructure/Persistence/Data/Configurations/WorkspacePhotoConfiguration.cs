using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DeskBooking.Domain.Entities;

namespace DeskBooking.Infrastructure.Persistence.Data.Configurations;

public class WorkspacePhotoConfiguration : IEntityTypeConfiguration<WorkspacePhoto>
{
    public void Configure(EntityTypeBuilder<WorkspacePhoto> builder)
    {
        builder.Property(wp => wp.Title)
            .HasMaxLength(50);
    }
}