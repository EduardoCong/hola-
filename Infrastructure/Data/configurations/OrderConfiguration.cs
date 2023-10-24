using System.Collections.Immutable;
using TostiElotes.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TostiElotes.Infrastructure.Data.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Orden>
    {
        public void Configure(EntityTypeBuilder<Orden> builder)
        {
            builder.ToTable("Orden");
            builder.HasKey(e => e.IdOrden).HasName("PK__Orden__C38F300DE2481AC0");

            builder.Property(e => e.DetallesPago).HasColumnType("text");
            builder.Property(e => e.DireccionEnvio).HasColumnType("text");
            builder.Property(e => e.Fecha).HasColumnType("datetime");

            builder.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Orden)
                .HasForeignKey(d => d.IdCliente)
                .HasConstraintName("FK__Orden__IdCliente__5AEE82B9");

            builder.HasOne(d => d.IdVendedorNavigation).WithMany(p => p.Orden)
                .HasForeignKey(d => d.IdVendedor)
                .HasConstraintName("FK__Orden__IdVendedo__5BE2A6F2");
        }
    }
}