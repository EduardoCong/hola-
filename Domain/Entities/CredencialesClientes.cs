using System;
using System.Collections.Generic;

namespace TostiElotes.Domain.Entities;

public partial class CredencialesCliente
{
    public int IdUsuario { get; set; }

    public int? IdCliente { get; set; }

    public string NomUsuario { get; set; } = null!;

    public string Contraseña { get; set; } = null!;

    public virtual Cliente? IdClienteNavigation { get; set; }
}
