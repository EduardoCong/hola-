using System;
using System.Collections.Generic;

namespace TostiElotes.Domain.Entities;

public partial class VendedoresProducto
{
    public int IdVendedorProducto { get; set; }

    public int? IdPuesto { get; set; }

    public int? IdProducto { get; set; }

    public virtual Producto? IdProductoNavigation { get; set; }

    public virtual PuestosNegocio? IdPuestoNavigation { get; set; }
}
