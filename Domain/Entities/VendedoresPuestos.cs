using System;
using System.Collections.Generic;

namespace TostiElotes.Domain.Entities;

public partial class VendedoresPuesto
{
    public int IdRelacion { get; set; }

    public int? IdVendedor { get; set; }

    public int? IdPuesto { get; set; }

    public virtual PuestosNegocio? IdPuestoNavigation { get; set; }

    public virtual Vendedor? IdVendedorNavigation { get; set; }
}
