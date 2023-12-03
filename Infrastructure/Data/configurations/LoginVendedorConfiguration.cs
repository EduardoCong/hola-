using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TostiElotes.Domain.Entities;
namespace TostiElotes.Infrastructure.Data.configurations
{
    public class LoginVendedorConfiguration:IEntityTypeConfiguration<CredencialesVendedore>
    {
        public void Configure(EntityTypeBuilder<CredencialesVendedore> builder)
        {
            builder.ToTable("CredencialesVendedores");
            builder.HasKey(e => e.IdCredencial).HasName("PK__Credenci__E81A3BAA46C21DC9");

            builder.Property(e => e.IdCredencial).HasColumnName("id_credencial");
            builder.Property(e => e.Contraseña)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("contraseña");
            builder.Property(e => e.IdVendedor).HasColumnName("id_vendedor");
            builder.Property(e => e.Usuario)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("usuario");

            builder.HasOne(d => d.IdVendedorNavigation).WithMany(p => p.CredencialesVendedores)
                .HasForeignKey(d => d.IdVendedor)
                .HasConstraintName("FK__Credencia__id_ve__4B422AD5");
        }
    }
}