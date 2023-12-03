using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TostiElotes.Domain.Entities;
namespace TostiElotes.Infrastructure.Data.configurations
{
    public class SeguimientoEstadoConfiguration:IEntityTypeConfiguration<SeguimientoEstado>
    {
        public void Configure(EntityTypeBuilder<SeguimientoEstado> builder)
        {
            builder.ToTable("SeguimientoEstado");
            builder.HasKey(e => e.IdSeguimiento).HasName("PK__Seguimie__127E9A1AD87DF228");

            builder.Property(e => e.IdSeguimiento).HasColumnName("id_seguimiento");
            builder.Property(e => e.EstadoActual)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("estado_actual");
            builder.Property(e => e.EstadoAnterior)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("estado_anterior");
            builder.Property(e => e.FechaCambio)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fecha_cambio");
            builder.Property(e => e.IdOrden).HasColumnName("id_orden");

            builder.HasOne(d => d.IdOrdenNavigation).WithMany(p => p.SeguimientoEstado)
                .HasForeignKey(d => d.IdOrden)
                .HasConstraintName("FK_OrdenSeguimiento");
        }
    }
}