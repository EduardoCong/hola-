using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TostiElotes.Domain.Dtos
{
        public class VendedorPuestoDTO
    {
         public int IdRelacion { get; set; }

    public int? IdVendedor { get; set; }

    public int? IdPuesto { get; set; }
    }
}