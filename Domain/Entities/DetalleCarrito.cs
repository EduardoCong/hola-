using System;
using System.Collections.Generic;

namespace TostiElotes.Domain.Entities;

public partial class DetalleCarrito
{
    public int IdDetalle { get; set; }

    public int? IdCarrito { get; set; }

    public int? IdProducto { get; set; }

    public int? Cantidad { get; set; }

    public string? Extras { get; set; }

    public virtual CarritoDeCompra? IdCarritoNavigation { get; set; }

    public virtual Producto? IdProductoNavigation { get; set; }
}
