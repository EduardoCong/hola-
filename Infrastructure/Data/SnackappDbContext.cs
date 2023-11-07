using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TostiElotes.Infrastructure.Data.Configurations;

namespace TostiElotes.Domain.Entities;

public partial class SnackappDbContext : DbContext
{
    public SnackappDbContext()
    {
    }

    public SnackappDbContext(DbContextOptions<SnackappDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Cliente { get; set; }

    public virtual DbSet<DetalleOrden> DetallesOrden { get; set; }

    public virtual DbSet<EstadoEntrega> EstadoEntrega { get; set; }

    public virtual DbSet<Orden> Orden { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Vendedor> Vendedores { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ClienteConfiguration());

        modelBuilder.ApplyConfiguration(new DetalleOrdenConfiguration());

        modelBuilder.ApplyConfiguration(new EstadoEntregaConfiguration());

        modelBuilder.ApplyConfiguration(new OrderConfiguration());

        modelBuilder.ApplyConfiguration(new ProductoConfiguration());

        modelBuilder.ApplyConfiguration(new VendedorConfiguration());
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
