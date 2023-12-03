using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TostiElotes.Domain.Entities;

namespace TostiElotes.Infrastructure.Data.configurations
{
    public class VendedoresPuestoConfiguration:IEntityTypeConfiguration<VendedoresPuesto>
    {
        public void Configure(EntityTypeBuilder<VendedoresPuesto> builder)
        {
            builder.ToTable("Vendedores_Puestos");
             builder.HasKey(e => e.IdRelacion).HasName("PK__Vendedor__51F3AF4C120E0401");

            builder.ToTable("Vendedores_Puestos");

            builder.Property(e => e.IdRelacion).HasColumnName("id_relacion");
            builder.Property(e => e.IdPuesto).HasColumnName("id_puesto");
            builder.Property(e => e.IdVendedor).HasColumnName("id_vendedor");

            builder.HasOne(d => d.IdPuestoNavigation).WithMany(p => p.VendedoresPuestos)
                .HasForeignKey(d => d.IdPuesto)
                .HasConstraintName("FK__Vendedore__id_pu__4865BE2A");

            builder.HasOne(d => d.IdVendedorNavigation).WithMany(p => p.VendedoresPuestos)
                .HasForeignKey(d => d.IdVendedor)
                .HasConstraintName("FK__Vendedore__id_ve__477199F1");
        }
    }
}