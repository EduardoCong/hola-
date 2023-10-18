using System;
using System.Collections.Generic;

namespace TostiElotes.Domain.Entities;

public partial class Orden
{
    public int IdOrden { get; set; }

    public byte[] Fecha { get; set; } = null!;

    public int? IdCliente { get; set; }

    public int? IdVendedor { get; set; }

    public string? DireccionEnvio { get; set; }

    public string? DetallesPago { get; set; }
}
