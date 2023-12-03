using System;
using System.Collections.Generic;

namespace TostiElotes.Domain.Entities;

public partial class SeguimientoEstado
{
    public int IdSeguimiento { get; set; }

    public int? IdOrden { get; set; }

    public string? EstadoAnterior { get; set; }

    public string? EstadoActual { get; set; }

    public DateTime? FechaCambio { get; set; }

    public virtual Orden? IdOrdenNavigation { get; set; }
}
