using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TostiElotes.Domain.Entities;
namespace TostiElotes.Infrastructure.Data.configurations
{
    public class ExtraConfiguration : IEntityTypeConfiguration<Producto>
    {
        public void Configure(EntityTypeBuilder<Producto> builder)
        {
            builder.ToTable("Extras");

            builder.HasKey(e => e.Id).HasName("PK__Extras__3214EC278F435384");

            builder.Property(e => e.Id).HasColumnName("ID");
            builder.Property(e => e.DescripcionExtra).HasColumnType("text");
            builder.Property(e => e.IdProducto).HasColumnName("ID_Producto");
            builder.Property(e => e.NombreExtra)
                .HasMaxLength(255)
                .IsUnicode(false);
            builder.Property(e => e.PrecioExtra).HasColumnType("decimal(10, 2)");

            builder.HasOne(d => d.IdProductoNavigation).WithMany(p => p.Extras)
                .HasForeignKey(d => d.IdProducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_producto");


        }
    }
}