using System;
using System.Collections.Generic;

namespace TostiElotes.Domain.Entities;

public partial class DetalleOrden
{
    public int IdDetalle { get; set; }

    public int? IdOrden { get; set; }

    public int? IdProducto { get; set; }

    public int? Cantidad { get; set; }

    public decimal? PrecioTotal { get; set; }

    public virtual Orden? IdOrdenNavigation { get; set; }

    public virtual Producto? IdProductoNavigation { get; set; }
}
