using System;
using System.Collections.Generic;

namespace TostiElotes.Domain.Entities;

public partial class EstadoEntrega
{
    public int IdEstado { get; set; }

    public int IdOrden { get; set; }

    public string? Estado { get; set; }

    public string? Comentarios { get; set; }

    public virtual Orden? IdOrdenNavigation { get; set; }
}
