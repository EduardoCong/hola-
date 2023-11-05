using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TostiElotes.Domain.Dtos
{
    public class OrderDTO
    {
        public int ID_Orden { get; set; }

        public DateTime? Fecha { get; set; }

        public int? IdCliente { get; set; }

        public int? IdVendedor { get; set; }

        public string? DireccionEnvio { get; set; }

        public string? DetallesPago { get; set; }
        public List<DetalleOrdenDTO>? DetalleOrden { get; set; }

    }

}