using System;
using System.Collections.Generic;

namespace TostiElotes.Domain.Entities;

public partial class Orden
{
    public int IdOrden { get; set; }

    public int? IdCarrito { get; set; }

    public string? Estado { get; set; }

    public int? RepartidorId { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaActualizacion { get; set; }

    public virtual CarritoDeCompra? IdCarritoNavigation { get; set; }

    public virtual Repartidor? Repartidor { get; set; }

    public virtual ICollection<SeguimientoEstado> SeguimientoEstado { get; set; } = new List<SeguimientoEstado>();
}
