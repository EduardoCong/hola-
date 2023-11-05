using System;
using System.Collections.Generic;

namespace TostiElotes.Domain.Entities;

public partial class Cliente
{
    public int IdCliente { get; set; }
    public string? Nombre { get; set; }
    public string? Apellido { get; set; }
    public string? Email { get; set; }
    public string? Telefono { get; set; }
    public string? Direccion { get; set; }
    public string? Contraseña { get; set; }

    public virtual ICollection<Orden> Orden { get; set; } = new List<Orden>();
}
