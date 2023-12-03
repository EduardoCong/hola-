using System;
using System.Collections.Generic;

namespace TostiElotes.Domain.Entities;

public partial class Notificacione
{
    public int IdNotificacion { get; set; }

    public int? IdVendedor { get; set; }

    public string Mensaje { get; set; } = null!;

    public DateTime Fecha { get; set; }

    public string Estado { get; set; } = null!;

    public virtual Vendedor? IdVendedorNavigation { get; set; }
}
