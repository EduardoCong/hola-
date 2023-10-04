using TostiElotes.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TostiElotes.Infrastructure.Data.Configurations;

public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        builder.ToTable("Usuarios");
        builder.HasKey(e => e.id).HasName("PK__Usuarios__3213E83FD3E1C3D4");

            builder.Property(e => e.id).HasColumnName("id");
            builder.Property(e => e.email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            builder.Property(e => e.first_Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("first_name");
            builder.Property(e => e.last_Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("last_name");

        
    }
}