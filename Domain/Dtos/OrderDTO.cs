using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TostiElotes.Domain.Dtos
{
    public class OrderDTO
    {
        public int ID_Orden { get; set; }
        public DateTime Fecha { get; set; }
        public int ID_Cliente { get; set; }
        public int ID_Vendedor { get; set; }
        public string? Estado { get; set; }
        public string? DireccionEnvio { get; set; }
        public string? DetallesPago { get; set; }
    
    }

}