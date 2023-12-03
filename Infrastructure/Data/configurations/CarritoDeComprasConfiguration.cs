using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TostiElotes.Domain.Entities;

namespace TostiElotes.Infrastructure.Data.configurations
{
    public class CarritoDeComprasConfiguration :IEntityTypeConfiguration<CarritoDeCompra>
    {
        public void Configure(EntityTypeBuilder<CarritoDeCompra> builder)
        {
            builder.ToTable("CarritoDeCompras");
            builder.HasKey(e => e.IdCarrito).HasName("PK__CarritoD__83A2AD9C71893E71");

            builder.Property(e => e.IdCarrito).HasColumnName("id_carrito");
            builder.Property(e => e.Estado)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("estado");
            builder.Property(e => e.IdCliente).HasColumnName("id_cliente");
            builder.Property(e => e.MetodoEntrega)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("metodo_entrega");
            builder.Property(e => e.Total)
                .HasDefaultValueSql("((0))")
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("total");

            builder.HasOne(d => d.IdClienteNavigation).WithMany(p => p.CarritoDeCompras)
                .HasForeignKey(d => d.IdCliente)
                .HasConstraintName("FK_ClienteCarrito");
            
        }
    }
}