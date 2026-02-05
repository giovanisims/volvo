using AutoManage.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutoManage.Data.Configurations;

public class SalespersonConfig : IEntityTypeConfiguration<Salesperson>
{
    public void Configure(EntityTypeBuilder<Salesperson> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasMany(x => x.Sales)
            .WithOne(x => x.Salesperson)
            .HasForeignKey(x => x.SalespersonId);
    }
}
