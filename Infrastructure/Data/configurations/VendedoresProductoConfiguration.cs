using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TostiElotes.Domain.Entities;

namespace TostiElotes.Infrastructure.Data.configurations
{
    public class VendedoresProductoConfiguration:IEntityTypeConfiguration<VendedoresProducto>
    {
        public void Configure(EntityTypeBuilder<VendedoresProducto> builder)
        {
            builder.ToTable("Vendedores_Productos");
            builder.HasKey(e => e.IdVendedorProducto).HasName("PK__Vendedor__48175BDE6F564D24");

            builder.ToTable("Vendedores_Productos");

            builder.Property(e => e.IdVendedorProducto).HasColumnName("id_vendedor_producto");
            builder.Property(e => e.IdProducto).HasColumnName("id_producto");
            builder.Property(e => e.IdPuesto).HasColumnName("id_puesto");

            builder.HasOne(d => d.IdProductoNavigation).WithMany(p => p.VendedoresProductos)
                .HasForeignKey(d => d.IdProducto)
                .HasConstraintName("FK__Vendedore__id_pr__4F12BBB9");

            builder.HasOne(d => d.IdPuestoNavigation).WithMany(p => p.VendedoresProductos)
                .HasForeignKey(d => d.IdPuesto)
                .HasConstraintName("FK__Vendedore__id_pu__4E1E9780");
        }
    }
}