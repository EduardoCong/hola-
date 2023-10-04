using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TostiElotes.Infrastructure.Data.Configurations;

namespace TostiElotes.Domain.Entities;

public partial class ContexdataDB : DbContext
{
   
    public ContexdataDB(DbContextOptions<ContexdataDB> options)
        : base(options)
    {
    }

    public virtual DbSet<Order> Order { get; set; }

    public virtual DbSet<Orders> Orders { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {


        modelBuilder.Entity<Orders>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Orders__3213E83F0F7559C8");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CustomerName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.IdUser).HasColumnName("idUser");
            entity.Property(e => e.OrderDate).HasColumnType("datetime");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("FK__Orders__idUser__4F7CD00D");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            
        });
        
        modelBuilder.ApplyConfiguration(new ProductoConfiguration());
        modelBuilder.ApplyConfiguration(new OrderConfiguration());
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
