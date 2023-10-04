using System.Collections.Immutable;
using TostiElotes.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TostiElotes.Infrastructure.Data.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Order");
            builder.HasKey(e => e.Id).HasName("PK__Order__3213E83FE42F6884");
            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.Address)
                .HasMaxLength(100)
                .IsUnicode(false);
            builder.Property(e => e.CustomerName)
                .HasMaxLength(100)
                .IsUnicode(false);
            builder.Property(e => e.IdProduct).HasColumnName("idProduct");
            builder.HasOne(d => d.IdProductNavigation).WithMany(p => p.Order)
                .HasForeignKey(d => d.IdProduct)
                .HasConstraintName("FK__Order__idProduct__6D0D32F4");
        }        
    }
}