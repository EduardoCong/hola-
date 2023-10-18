using System;
using System.Collections.Generic;

namespace TostiElotes.Domain.Entities;

public partial class Vendedor
{
    public int IdVendedor { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public string? CorreoElectronico { get; set; }

    public string? Contraseña { get; set; }
}
