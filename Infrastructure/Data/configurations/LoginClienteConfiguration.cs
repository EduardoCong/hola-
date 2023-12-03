using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TostiElotes.Domain.Entities;

namespace TostiElotes.Infrastructure.Data.configurations
{
    public class LoginClienteConfiguration:IEntityTypeConfiguration<CredencialesCliente>
    {
        public void Configure(EntityTypeBuilder<CredencialesCliente> builder)
        {
            builder.ToTable("CredencialesClientes");
            builder.HasKey(e => e.IdUsuario).HasName("PK__Credenci__4E3E04ADCF6511EF");

            builder.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            builder.Property(e => e.Contraseña)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("contraseña");
            builder.Property(e => e.IdCliente).HasColumnName("id_cliente");
            builder.Property(e => e.NomUsuario)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nom_usuario");

            builder.HasOne(d => d.IdClienteNavigation).WithMany(p => p.CredencialesClientes)
                .HasForeignKey(d => d.IdCliente)
                .HasConstraintName("FK__Credencia__id_cl__53D770D6");
        }
    }
}