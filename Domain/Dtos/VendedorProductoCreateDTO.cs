using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TostiElotes.Domain.Dtos
{
     public class VendedorProductoDTO
    {
        public int IdVendedorProducto { get; set; }

    public int? IdVendedor { get; set; }

    public int? IdProducto { get; set; }
    }
}