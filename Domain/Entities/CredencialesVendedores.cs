using System;
using System.Collections.Generic;

namespace TostiElotes.Domain.Entities;

public partial class CredencialesVendedore
{
    public int IdCredencial { get; set; }

    public int? IdVendedor { get; set; }

    public string Usuario { get; set; } = null!;

    public string Contraseña { get; set; } = null!;

    public virtual Vendedor? IdVendedorNavigation { get; set; }
}
