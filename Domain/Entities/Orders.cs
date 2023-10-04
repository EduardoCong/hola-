using System;
using System.Collections.Generic;

namespace TostiElotes.Domain.Entities;

public partial class Orders
{
    public int Id { get; set; }

    public string CustomerName { get; set; } = null!;

    public string Address { get; set; } = null!;

    public DateTime OrderDate { get; set; }

    public int? IdUser { get; set; }

    public virtual Usuario? IdUserNavigation { get; set; }
}
