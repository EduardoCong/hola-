using System;
using System.Collections.Generic;

namespace TostiElotes.Domain.Entities;

public partial class Orden
{
    public int IdOrden { get; set; }

    public DateTime? Fecha { get; set; }

    public int? IdCliente { get; set; }

    public int? IdVendedor { get; set; }

    public string? DireccionEnvio { get; set; }

    public string? DetallesPago { get; set; }

    public virtual ICollection<DetalleOrden> DetallesOrden { get; set; } = new List<DetalleOrden>();

    public virtual ICollection<EstadoEntrega> EstadoEntrega { get; set; } = new List<EstadoEntrega>();

    public virtual Cliente? IdClienteNavigation { get; set; }

    public virtual Vendedor? IdVendedorNavigation { get; set; }
}
