using TostiElotes.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TostiElotes.Infrastructure.Data.Configurations
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Clientes");
             builder.HasKey(e => e.IdCliente).HasName("PK__Clientes__D59466427BFF81D3");

            builder.Property(e => e.Apellido)
                .HasMaxLength(50)
                .IsUnicode(false);
            builder.Property(e => e.Contraseña)
                .HasMaxLength(255)
                .IsUnicode(false);
            builder.Property(e => e.CorreoElectronico)
                .HasMaxLength(255)
                .IsUnicode(false);
            builder.Property(e => e.Direccion).HasColumnType("text");
            builder.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            builder.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            builder.Property(e => e.Telefono)
                .HasMaxLength(15)
                .IsUnicode(false);        }

    }
}