using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TostiElotes.Domain.Dtos
{
    public class DetalleOrdenDTO
    {
        public int ID_Detalle { get; set; }
        public int ID_Orden { get; set; }
        public int ID_Producto { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioTotal { get; set; }
    }
}