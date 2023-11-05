using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TostiElotes.Domain.Dtos
{
    public class DetalleOrdenCreateDTO
    {
        public int ID_Producto { get; set; }
        public int Cantidad { get; set; }
    }
}