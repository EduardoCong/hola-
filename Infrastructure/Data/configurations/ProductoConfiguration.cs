using TostiElotes.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TostiElotes.Infrastructure.Data.Configurations
{
    public class ProductoConfiguration : IEntityTypeConfiguration<Producto>
    {
        public void Configure(EntityTypeBuilder<Producto> builder)
        {
            builder.ToTable("Productos");
            builder.HasKey(e => e.IdProducto).HasName("PK__Producto__9B4120E21BF5DF07");
            builder.Property(e => e.IdProducto)
                .ValueGeneratedNever()
                .HasColumnName("ID_Producto");
            builder.Property(e => e.Descripción).HasColumnType("text");
            builder.Property(e => e.Imagen)
                .HasMaxLength(255)
                .IsUnicode(false);
            builder.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false);
            builder.Property(e => e.Precio).HasColumnType("decimal(10, 2)");

        }

    }
}