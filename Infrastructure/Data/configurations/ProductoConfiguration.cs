using TostiElotes.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TostiElotes.Infrastructure.Data.Configurations
{
    public class ProductoConfiguration : IEntityTypeConfiguration<Producto>
    {
        public void Configure(EntityTypeBuilder<Producto> builder){
            builder.ToTable("Productos");
            builder.HasKey(e => e.Id).HasName("PK__Producto__3213E83F44E8D358");

            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false);
            builder.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
            builder.Property(e => e.Price).HasColumnType("decimal(10, 2)");
        }
        
    }
}