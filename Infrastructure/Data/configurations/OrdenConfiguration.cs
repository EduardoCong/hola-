using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TostiElotes.Domain.Entities;

namespace TostiElotes.Infrastructure.Data.configurations
{
    public class OrdenConfiguration:IEntityTypeConfiguration<Orden>
    {
        public void Configure(EntityTypeBuilder<Orden> builder)
        {
            builder.ToTable("Ordenes");
             builder.HasKey(e => e.IdOrden).HasName("PK__Ordenes__DD5B8F33DFB02D2A");

            builder.ToTable(tb => tb.HasTrigger("DespuesDeInsertarOrden"));

            builder.Property(e => e.IdOrden).HasColumnName("id_orden");
            builder.Property(e => e.Estado)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("estado");
            builder.Property(e => e.FechaActualizacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fecha_actualizacion");
            builder.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fecha_creacion");
            builder.Property(e => e.IdCarrito).HasColumnName("id_carrito");
            builder.Property(e => e.RepartidorId).HasColumnName("repartidor_id");

            builder.HasOne(d => d.IdCarritoNavigation).WithMany(p => p.Ordens)
                .HasForeignKey(d => d.IdCarrito)
                .HasConstraintName("FK_CarritoOrden");

            builder.HasOne(d => d.Repartidor).WithMany(p => p.Ordenes)
                .HasForeignKey(d => d.RepartidorId)
                .HasConstraintName("FK_RepartidorOrden");
        }
    }
}