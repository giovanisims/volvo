using AutoManage.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutoManage.Data.Configurations;

public class OwnerConfig : IEntityTypeConfiguration<Owner>
{
    public void Configure(EntityTypeBuilder<Owner> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasMany(x => x.Addresses)
            .WithOne(x => x.Owner)
            .HasForeignKey(x => x.OwnerId);
    }
}
