using System;
using System.Collections.Generic;

namespace TostiElotes.Domain.Entities;

public partial class CarritoDeCompra
{
    public int IdCarrito { get; set; }

    public int? IdCliente { get; set; }

    public string? Estado { get; set; }

    public decimal? Total { get; set; }

    public string? MetodoEntrega { get; set; }

    public virtual Cliente? IdClienteNavigation { get; set; }
    public virtual ICollection<DetalleCarrito> DetalleCarrito { get; set; } = new List<DetalleCarrito>();


    public virtual ICollection<Orden> Ordens { get; set; } = new List<Orden>();
}
