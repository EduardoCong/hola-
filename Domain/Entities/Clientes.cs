using System;
using System.Collections.Generic;

namespace TostiElotes.Domain.Entities;

public partial class Cliente
{
    public int IdCliente { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string? Telefono { get; set; }

    public string CorreoElectronico { get; set; } = null!;

    public string Contrasena { get; set; } = null!;

    public virtual ICollection<CarritoDeCompra> CarritoDeCompras { get; set; } = new List<CarritoDeCompra>();

    public virtual ICollection<CredencialesCliente> CredencialesClientes { get; set; } = new List<CredencialesCliente>();
}
