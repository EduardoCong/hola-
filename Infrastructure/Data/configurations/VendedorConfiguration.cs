using TostiElotes.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TostiElotes.Infrastructure.Data.Configurations
{
    public class VendedorConfiguration : IEntityTypeConfiguration<Vendedor>
    {
        public void Configure(EntityTypeBuilder<Vendedor> builder)
        {
            builder.ToTable("Vendedores");
            builder.HasKey(e => e.IdVendedor).HasName("PK__Vendedor__16D6C7CA6768EE06");
            builder.Property(e => e.Contraseña).HasMaxLength(50);
            builder.Property(e => e.CorreoElectronico).HasMaxLength(100);
            builder.Property(e => e.Descripcion).HasMaxLength(255);
            builder.Property(e => e.Nombre).HasMaxLength(50);

        }

    }
}