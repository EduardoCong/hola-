using System;
using System.Collections.Generic;

namespace TostiElotes.Domain.Entities;

public partial class Order
{
    public int Id { get; set; }

    public string CustomerName { get; set; } = null!;

    public string Address { get; set; } = null!;

    public int Quantity { get; set; }

    public int? IdProduct { get; set; }

    public virtual Producto? IdProductNavigation { get; set; }
}
