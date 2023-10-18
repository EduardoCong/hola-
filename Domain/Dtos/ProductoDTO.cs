using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TostiElotes.Domain.Dtos
{
    public class ProductoDTO
    {
        public int ID_Producto { get; set; }
        public string? Nombre { get; set; } = null!;
        public string? Descripcion { get; set; }
        public decimal Precio { get; set; }  
        public int Stock { get; set; }
        public bool Disponibilidad { get; set; }
        public string? Imagen { get; set; }

    }
}