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
            builder.ToTable("Order");
           builder.HasKey(e => e.IdOrden).HasName("PK__Orden__EC9FA949F778BCE0");

            builder.Property(e => e.IdOrden)
                .ValueGeneratedNever()
                .HasColumnName("ID_Orden");
            builder.Property(e => e.DetallesPago).HasColumnType("text");
            builder.Property(e => e.DireccionEnvio).HasColumnType("text");
            builder.Property(e => e.Fecha)
                .IsRowVersion()
                .IsConcurrencyToken();
            builder.Property(e => e.IdCliente).HasColumnName("ID_Cliente");
            builder.Property(e => e.IdVendedor).HasColumnName("ID_Vendedor");
        }        
    }
}