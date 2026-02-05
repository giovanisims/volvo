using AutoManage.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutoManage.Data.Configurations;

public class VehicleConfig : IEntityTypeConfiguration<Vehicle>
{
    public void Configure(EntityTypeBuilder<Vehicle> builder)
    {
        builder.HasKey(x => v.Id);

        builder.HasIndex(x => v.Chassis).IsUnique();

        builder.HasOne(x => v.Owner)
            .WithMany()
            .HasForeignKey(x => v.OwnerId);

        builder.HasMany(x => v.Accessories)
            .WithOne(x => v.Vehicle)
            .HasForeignKey(x => v.VehicleId);
    }
}