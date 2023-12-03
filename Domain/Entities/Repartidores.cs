using System;
using System.Collections.Generic;

namespace TostiElotes.Domain.Entities;

public partial class Repartidor
{
    public int IdRepartidor { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public string CorreoElectronico { get; set; } = null!;

    public string Contraseña { get; set; } = null!;

    public virtual ICollection<Orden> Ordenes { get; set; } = new List<Orden>();
}
