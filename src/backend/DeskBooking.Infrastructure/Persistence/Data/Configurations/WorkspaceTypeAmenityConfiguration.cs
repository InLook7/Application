using DeskBooking.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DeskBooking.Infrastructure.Persistence.Data.Configurations;

public class WorkspaceTypeAmenityConfiguration : IEntityTypeConfiguration<WorkspaceTypeAmenity>
{
    public void Configure(EntityTypeBuilder<WorkspaceTypeAmenity> builder)
    {
        builder.HasKey(wta => new { wta.WorkspaceTypeId, wta.AmenityId });
    }
}