using System;
using System.Collections.Generic;

namespace TostiElotes.Domain.Entities;

public partial class Extras
{
    public int Id { get; set; }

    public int IdProducto { get; set; }

    public string NombreExtra { get; set; } = null!;

    public string? DescripcionExtra { get; set; }

    public decimal PrecioExtra { get; set; }

}
