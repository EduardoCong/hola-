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
            builder.HasKey(e => e.IdVendedor).HasName("PK__Vendedor__2B2A0A45D632271D");

            builder.Property(e => e.IdVendedor)
                .ValueGeneratedNever()
                .HasColumnName("ID_Vendedor");
            builder.Property(e => e.Contraseña)
                .HasMaxLength(255)
                .IsUnicode(false);
            builder.Property(e => e.CorreoElectronico)
                .HasMaxLength(255)
                .IsUnicode(false);
            builder.Property(e => e.Descripcion).HasColumnType("text");
            builder.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);

        }

    }
}