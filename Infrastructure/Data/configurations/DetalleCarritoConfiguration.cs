using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TostiElotes.Domain.Entities;

namespace TostiElotes.Infrastructure.Data.configurations
{
    public class DetalleCarritoConfiguration:IEntityTypeConfiguration<DetalleCarrito>
    {
        public void Configure(EntityTypeBuilder<DetalleCarrito> builder)
        {
            builder.ToTable("DetalleCarrito");
             builder.HasKey(e => e.IdDetalle).HasName("PK__DetalleC__4F1332DE30491554");

            builder.ToTable(tb =>
                {
                    tb.HasTrigger("AfterInsertDetalleCarrito");
                    tb.HasTrigger("AfterInsertOrUpdateDetalleCarrito");
                });

            builder.Property(e => e.IdDetalle).HasColumnName("id_detalle");
            builder.Property(e => e.Cantidad).HasColumnName("cantidad");
            builder.Property(e => e.Extras)
                .IsUnicode(false)
                .HasColumnName("extras");
            builder.Property(e => e.IdCarrito).HasColumnName("id_carrito");
            builder.Property(e => e.IdProducto).HasColumnName("id_producto");

            builder.HasOne(d => d.IdCarritoNavigation).WithMany(p => p.DetalleCarrito)
                .HasForeignKey(d => d.IdCarrito)
                .HasConstraintName("FK_CarritoDetalle");

            builder.HasOne(d => d.IdProductoNavigation).WithMany(p => p.DetalleCarrito)
                .HasForeignKey(d => d.IdProducto)
                .HasConstraintName("FK_ProductoDetalle");
        }
    }
}