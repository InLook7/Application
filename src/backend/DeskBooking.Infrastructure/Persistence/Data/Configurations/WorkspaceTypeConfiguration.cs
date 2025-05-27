using DeskBooking.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DeskBooking.Infrastructure.Persistence.Data.Configurations;

public class WorkspaceTypeConfiguration : IEntityTypeConfiguration<WorkspaceType>
{
    public void Configure(EntityTypeBuilder<WorkspaceType> builder)
    {
        builder.HasIndex(wt => wt.Name)
            .IsUnique();

        builder.Property(wt => wt.Name)
            .HasMaxLength(50);

        builder.Property(wt => wt.Description)
            .HasMaxLength(1000);
    }
}