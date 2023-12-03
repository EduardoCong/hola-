using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TostiElotes.Domain.Entities;

namespace TostiElotes.Infrastructure.Data.configurations
{
    public class NotificacionConfiguration:IEntityTypeConfiguration<Notificacione>
    {
        public void Configure(EntityTypeBuilder<Notificacione> builder)
        {
            builder.ToTable("Notificaciones");
             builder.HasKey(e => e.IdNotificacion).HasName("PK__Notifica__8270F9A50F9297D9");

            builder.Property(e => e.IdNotificacion).HasColumnName("id_notificacion");
            builder.Property(e => e.Estado)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("estado");
            builder.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("fecha");
            builder.Property(e => e.IdVendedor).HasColumnName("id_vendedor");
            builder.Property(e => e.Mensaje)
                .HasColumnType("text")
                .HasColumnName("mensaje");

            builder.HasOne(d => d.IdVendedorNavigation).WithMany(p => p.Notificaciones)
                .HasForeignKey(d => d.IdVendedor)
                .HasConstraintName("FK_VendedorNotificacion");
        }
    }
}