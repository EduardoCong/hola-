using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TostiElotes.Domain.Entities;

namespace TostiElotes.Infrastructure.Data.configurations
{
    public class RepartidorConfiguration:IEntityTypeConfiguration<Repartidor>
    {
        public void Configure(EntityTypeBuilder<Repartidor> builder)
        {
            builder.ToTable("Repartidores");
            builder.HasKey(e => e.IdRepartidor).HasName("PK__Repartid__3D17037BFC114536");

            builder.Property(e => e.IdRepartidor).HasColumnName("id_repartidor");
            builder.Property(e => e.Apellido)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("apellido");
            builder.Property(e => e.Contraseña)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("contraseña");
            builder.Property(e => e.CorreoElectronico)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("correo_electronico");
            builder.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
            builder.Property(e => e.Telefono)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("telefono");
        }
    }
}