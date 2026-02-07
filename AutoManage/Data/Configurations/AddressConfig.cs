using AutoManage.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutoManage.Data.Configurations;

public class AddressConfig : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.Property(x => x.CEP).HasMaxLength(20);
        builder.Property(x => x.State).HasMaxLength(100);
        builder.Property(x => x.City).HasMaxLength(100);
        builder.Property(x => x.Neighborhood).HasMaxLength(100);
        builder.Property(x => x.Street).HasMaxLength(100);
        builder.Property(x => x.Number).HasMaxLength(20);
        builder.Property(x => x.Complement).HasMaxLength(100);

        builder.HasOne(x => x.Owner)
            .WithMany(x => x.Addresses)
            .HasForeignKey(x => x.OwnerId);
    }
}
