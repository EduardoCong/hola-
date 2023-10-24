using System;
using System.Collections.Generic;

namespace TostiElotes.Domain.Entities;

public partial class Producto
{
    public int IdProducto { get; set; }

    public string? Nombre { get; set; }

    public string? Descripción { get; set; }

    public decimal? Precio { get; set; }

    public int? Stock { get; set; }

    public string? Imagen { get; set; }

    public virtual ICollection<DetalleOrden> DetallesOrden { get; set; } = new List<DetalleOrden>();
}
