using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TostiElotes.Domain.Entities;
namespace TostiElotes.Infrastructure.Data.configurations
{
    public class ProductoConfiguration:IEntityTypeConfiguration<Producto>
    {
        public void Configure(EntityTypeBuilder<Producto> builder)
        {
            builder.ToTable("Productos");
            builder.HasKey(e => e.Id).HasName("PK__Producto__3214EC27191B467C");

            builder.ToTable(tb => tb.HasTrigger("AfterInsertPuesto_Producto"));

            builder.HasIndex(e => e.ClaveProducto, "UQ__Producto__9F43F8E10CF1784B").IsUnique();

            builder.Property(e => e.Id).HasColumnName("ID");
            builder.Property(e => e.Categoria)
                .HasMaxLength(255)
                .IsUnicode(false);
            builder.Property(e => e.ClaveProducto)
                .HasMaxLength(255)
                .IsUnicode(false);
            builder.Property(e => e.Descripcion).HasColumnType("text");
            builder.Property(e => e.IdPuesto).HasColumnName("Id_puesto");
            builder.Property(e => e.NombreProducto)
                .HasMaxLength(255)
                .IsUnicode(false);
            builder.Property(e => e.Precio).HasColumnType("decimal(10, 2)");
            builder.Property(e => e.PromocionesDescuentos)
                .HasMaxLength(255)
                .IsUnicode(false);
            builder.Property(e => e.Sabor)
                .HasMaxLength(255)
                .IsUnicode(false);
            builder.Property(e => e.Tamano)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.HasOne(d => d.IdPuestoNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.IdPuesto)
                .HasConstraintName("FK__Productos__Id_pu__44952D46");
        }
    }
}