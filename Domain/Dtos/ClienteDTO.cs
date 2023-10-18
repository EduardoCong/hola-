using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TostiElotes.Domain.Dtos
{
    public class ClienteDTO
    {
        public int ID_Cliente { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Email { get; set; }
        public string? Telefono { get; set; }
        public string? Direccion { get; set; }
        public string? CorreoElectronico { get; set; }  
        public string? Contraseña { get; set; } 
    }
}