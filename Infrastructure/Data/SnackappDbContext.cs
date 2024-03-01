using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TostiElotes.Infrastructure.Data.configurations;

namespace TostiElotes.Domain.Entities;

public partial class SnackappDbContext : DbContext
{


    public SnackappDbContext(DbContextOptions<SnackappDbContext> options)
        : base(options)
    {
    }
    public virtual DbSet<CarritoDeCompra> CarritoDeCompras { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<CredencialesCliente> CredencialesClientes { get; set; }

    public virtual DbSet<CredencialesVendedore> CredencialesVendedores { get; set; }

    public virtual DbSet<DetalleCarrito> DetalleCarrito { get; set; }
    public virtual DbSet<Extra> Extra { get; set; }

    public virtual DbSet<Notificacione> Notificaciones { get; set; }

    public virtual DbSet<Orden> Ordenes { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<PuestosNegocio> PuestosNegocios { get; set; }

    public virtual DbSet<Repartidor> Repartidores { get; set; }

    public virtual DbSet<SeguimientoEstado> SeguimientoEstado { get; set; }

    public virtual DbSet<Vendedor> Vendedores { get; set; }

    public virtual DbSet<VendedoresProducto> VendedoresProductos { get; set; }

    public virtual DbSet<VendedoresPuesto> VendedoresPuestos { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CarritoDeComprasConfiguration());
        modelBuilder.ApplyConfiguration(new ExtrasConfiguration());
        modelBuilder.ApplyConfiguration(new ClienteConfiguration());
        modelBuilder.ApplyConfiguration(new DetalleCarritoConfiguration());
        modelBuilder.ApplyConfiguration(new LoginClienteConfiguration());
        modelBuilder.ApplyConfiguration(new LoginVendedorConfiguration());
        modelBuilder.ApplyConfiguration(new NotificacionConfiguration());
        modelBuilder.ApplyConfiguration(new OrdenConfiguration());
        modelBuilder.ApplyConfiguration(new ProductoConfiguration());
        modelBuilder.ApplyConfiguration(new PuestosNegocioConfiguratoon());
        modelBuilder.ApplyConfiguration(new RepartidorConfiguration());
        modelBuilder.ApplyConfiguration(new SeguimientoEstadoConfiguration());
        modelBuilder.ApplyConfiguration(new VendedorConfiguration());
        modelBuilder.ApplyConfiguration(new VendedoresProductoConfiguration());
        modelBuilder.ApplyConfiguration(new VendedoresPuestoConfiguration());

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
