using AutoManage.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutoManage.Data.Configurations;

public class OwnerConfig : IEntityTypeConfiguration<Owner>
{
    public void Configure(EntityTypeBuilder<Owner> builder)
    {
        builder.Property(x => x.Name).HasMaxLength(100);
        builder.Property(x => x.CPF_CNPJ).HasMaxLength(20);
        builder.Property(x => x.Email).HasMaxLength(255);
        builder.Property(x => x.Telephone).HasMaxLength(20);
        builder.Property(x => x.CNH).HasMaxLength(20);
        builder.Property(x => x.AdditionalInfo).HasMaxLength(500);
    }
}
