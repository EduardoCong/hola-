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

            builder.HasKey(e => e.IdOrden).HasName("PK__Orden__C38F300D0A4FCCE7");

            builder.Property(e => e.DireccionEnvio).HasMaxLength(255);
            builder.Property(e => e.Fecha).HasColumnType("datetime");

            builder.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Orden)
                .HasForeignKey(d => d.IdCliente)
                .HasConstraintName("FK__Orden__IdCliente__693CA210");

            builder.HasOne(d => d.IdVendedorNavigation).WithMany(p => p.Orden)
                .HasForeignKey(d => d.IdVendedor)
                .HasConstraintName("FK__Orden__IdVendedo__6A30C649");
        }

    }
}