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
        builder.HasKey(e => e.IdDetalle).HasName("PK__Detalles__E43646A5AB66561F");

        builder.Property(e => e.PrecioTotal).HasColumnType("decimal(10, 2)");

        builder.HasOne(d => d.IdOrdenNavigation).WithMany(p => p.DetallesOrden)
            .HasForeignKey(d => d.IdOrden)
            .HasConstraintName("FK__DetallesO__IdOrd__5EBF139D");

        builder.HasOne(d => d.IdProductoNavigation).WithMany(p => p.DetallesOrden)
            .HasForeignKey(d => d.IdProducto)
            .HasConstraintName("FK__DetallesO__IdPro__5FB337D6");


    }
}