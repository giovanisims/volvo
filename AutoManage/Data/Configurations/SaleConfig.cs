using AutoManage.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutoManage.Data.Configurations;

public class SaleConfig : IEntityTypeConfiguration<Sale>
{
    public void Configure(EntityTypeBuilder<Sale> builder)
    {
        builder.HasOne(x => x.Vehicle)
            .WithMany()
            .HasForeignKey(x => x.VehicleId);
            
        builder.HasOne(x => x.Salesperson)
            .WithMany(x => x.Sales)
            .HasForeignKey(x => x.SalespersonId);
    }
}
