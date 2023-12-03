using System;
using System.Collections.Generic;

namespace TostiElotes.Domain.Entities;

public partial class Vendedor
{
    public int IdVendedor { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public string CorreoElectronico { get; set; } = null!;

    public string Contraseña { get; set; } = null!;

    public virtual ICollection<CredencialesVendedore> CredencialesVendedores { get; set; } = new List<CredencialesVendedore>();

    public virtual ICollection<Notificacione> Notificaciones { get; set; } = new List<Notificacione>();

    public virtual ICollection<PuestosNegocio> PuestosNegocios { get; set; } = new List<PuestosNegocio>();

    public virtual ICollection<VendedoresPuesto> VendedoresPuestos { get; set; } = new List<VendedoresPuesto>();
}
