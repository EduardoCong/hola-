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
            builder.HasKey(e => e.IdProducto).HasName("PK__Producto__09889210A9C7F96E");

            builder.Property(e => e.Nombre).HasMaxLength(255);
            builder.Property(e => e.Precio).HasColumnType("decimal(10, 2)");
        }

    }
}