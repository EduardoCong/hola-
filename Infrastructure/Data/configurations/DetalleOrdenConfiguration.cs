using TostiElotes.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TostiElotes.Infrastructure.Data.Configurations;

public class DetalleOrdenConfiguration : IEntityTypeConfiguration<DetalleOrden>
{
    public void Configure(EntityTypeBuilder<DetalleOrden> builder)
    {
        builder.ToTable("DetallesOrden");
        builder.HasKey(e => e.IdDetalle).HasName("PK__Detalles__B3E0CED33E0ED109");

        builder.Property(e => e.IdDetalle)
            .ValueGeneratedNever()
            .HasColumnName("ID_Detalle");
        builder.Property(e => e.IdOrden).HasColumnName("ID_Orden");
        builder.Property(e => e.IdProducto).HasColumnName("ID_Producto");
        builder.Property(e => e.Cantidad).HasColumnType("int");
        builder.Property(e => e.PrecioTotal).HasColumnType("decimal(10, 2)");


    }
}