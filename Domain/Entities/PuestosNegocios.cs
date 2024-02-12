using System;
using System.Collections.Generic;

namespace TostiElotes.Domain.Entities;

public partial class PuestosNegocio
{
    public int Id { get; set; }

    public string NombreNegocio { get; set; } = null!;

    public string FotosRepresentativas { get; set; } = null!;

    public string UbicacionExacta { get; set; } = null!;

    public string HorarioAtencion { get; set; } = null!;

    public string MetodosPagoAceptados { get; set; } = null!;

    public string? InformacionAdicional { get; set; }

    public int? IdVendedor { get; set; }

    public virtual Vendedor? IdVendedorNavigation { get; set; }

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();

    public virtual ICollection<VendedoresProducto> VendedoresProductos { get; set; } = new List<VendedoresProducto>();

    public virtual ICollection<VendedoresPuesto> VendedoresPuestos { get; set; } = new List<VendedoresPuesto>();
}
