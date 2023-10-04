using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

namespace TostiElotes.Domain.Entities;

public partial class Usuario
{
    public int id { get; set; }

    public string? first_Name { get; set; }

    public string? last_Name { get; set; }

    public string? email { get; set; }

    public virtual ICollection<Orders> Orders { get; set; } = new List<Orders>();
}
