using AutoManage.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutoManage.Data.Configurations;

public class AccessoryConfig : IEntityTypeConfiguration<Accessory>
{
    public void Configure(EntityTypeBuilder<Accessory> builder)
    {
        builder.Property(x => x.Name).HasMaxLength(100);

        builder.HasOne(x => x.Vehicle)
            .WithMany(x => x.Accessories)
            .HasForeignKey(x => x.VehicleId);
    }
}
