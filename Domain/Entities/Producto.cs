using System;
using System.Collections.Generic;

namespace TostiElotes.Domain.Entities;

public partial class Producto
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public decimal Price { get; set; }

    public virtual ICollection<Order> Order { get; set; } = new List<Order>();
}
