using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TostiElotes.Domain.Entities;

namespace TostiElotes.Infrastructure.Data.configurations
{
    public class PuestosNegocioConfiguratoon:IEntityTypeConfiguration<PuestosNegocio>
    {
        public void Configure(EntityTypeBuilder<PuestosNegocio> builder)
        {
            builder.ToTable("PuestosNegocios");
            builder.HasKey(e => e.Id).HasName("PK__PuestosN__3214EC273976FBC4");

            builder.ToTable(tb => tb.HasTrigger("AfterInsertVendedor_Puesto"));

            builder.Property(e => e.Id).HasColumnName("ID");
            builder.Property(e => e.HorarioAtencion)
                .HasMaxLength(255)
                .IsUnicode(false);
            builder.Property(e => e.IdVendedor).HasColumnName("Id_vendedor");
            builder.Property(e => e.InformacionAdicional).HasColumnType("text");
            builder.Property(e => e.MetodosPagoAceptados)
                .HasMaxLength(255)
                .IsUnicode(false);
            builder.Property(e => e.NombreNegocio)
                .HasMaxLength(255)
                .IsUnicode(false);
            builder.Property(e => e.UbicacionExacta)
                .HasMaxLength(255)
                .IsUnicode(false);

            builder.HasOne(d => d.IdVendedorNavigation).WithMany(p => p.PuestosNegocios)
                .HasForeignKey(d => d.IdVendedor)
                .HasConstraintName("FK__PuestosNe__Id_ve__3EDC53F0");
        }
    }
}