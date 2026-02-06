using AutoManage.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutoManage.Data.Configurations;

public class VehicleConfig : IEntityTypeConfiguration<Vehicle>
{
    public void Configure(EntityTypeBuilder<Vehicle> builder)
    {
        builder.Property(x => x.Chassis).HasMaxLength(20);
        builder.Property(x => x.Model).HasMaxLength(100);
        builder.Property(x => x.Color).HasMaxLength(100);
        builder.Property(x => x.SystemVersion).HasMaxLength(100);

        builder.HasIndex(x => x.Chassis).IsUnique();

        builder.HasOne(x => x.Owner)
            .WithMany()
            .HasForeignKey(x => x.OwnerId);

        builder.HasMany(x => x.Accessories)
            .WithOne(x => x.Vehicle)
            .HasForeignKey(x => x.VehicleId);
    }
}