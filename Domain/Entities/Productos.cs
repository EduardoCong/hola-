using System;
using System.Collections.Generic;

namespace TostiElotes.Domain.Entities;

public partial class Producto
{
    public int Id { get; set; }

    public string Categoria { get; set; } = null!;

    public string ClaveProducto { get; set; } = null!;

    public string NombreProducto { get; set; } = null!;

    public string? Descripcion { get; set; }

    public string? ImagenProducto { get; set; }

    public string? Tamano { get; set; }

    public string? Sabor { get; set; }

    public decimal Precio { get; set; }

    public int Disponibilidad { get; set; }

    public string? PromocionesDescuentos { get; set; }

    public int? IdPuesto { get; set; }

    public virtual ICollection<DetalleCarrito> DetalleCarrito { get; set; } = new List<DetalleCarrito>();

    public virtual PuestosNegocio? IdPuestoNavigation { get; set; }

    public virtual ICollection<Extras> Extras { get; set; } = new List<Extras>();


    public virtual ICollection<VendedoresProducto> VendedoresProductos { get; set; } = new List<VendedoresProducto>();
}
