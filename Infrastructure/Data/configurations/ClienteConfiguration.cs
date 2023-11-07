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
            builder.HasKey(e => e.IdCliente).HasName("PK__Clientes__D5946642AA9DBA85");
            builder.Property(e => e.Apellido).HasMaxLength(50);
            builder.Property(e => e.Contraseña).HasMaxLength(50);
            builder.Property(e => e.Direccion).HasMaxLength(255);
            builder.Property(e => e.Email).HasMaxLength(100);
            builder.Property(e => e.Nombre).HasMaxLength(50);
            builder.Property(e => e.Telefono).HasMaxLength(20);
        }

    }
}
