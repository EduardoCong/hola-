using TostiElotes.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TostiElotes.Infrastructure.Data.Configurations
{
    public class EstadoEntregaConfiguration : IEntityTypeConfiguration<EstadoEntrega>
    {
        public void Configure(EntityTypeBuilder<EstadoEntrega> builder)
        {
            builder.ToTable("EstadoEntrega");
            builder.HasKey(e => e.IdEstado).HasName("PK__EstadoEn__FBB0EDC1A723426D");
            builder.Property(e => e.Estado).HasMaxLength(50);
            builder.HasOne(d => d.IdOrdenNavigation).WithMany(p => p.EstadoEntrega)
                .HasForeignKey(d => d.IdOrden)
                .HasConstraintName("FK__EstadoEnt__IdOrd__70DDC3D8");
        }
    }
}