using AutoManage.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutoManage.Data.Configurations;

public class AccessoryConfig : IEntityTypeConfiguration<Accessory>
{
    public void Configure(EntityTypeBuilder<Accessory> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Vehicle)
            .WithMany(x => x.Accessories)
            .HasForeignKey(x => x.VehicleId);
    }
}
