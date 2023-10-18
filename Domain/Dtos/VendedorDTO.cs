using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TostiElotes.Domain.Dtos
{
    public class VendedorDTO
    {
        public int ID_Vendedor { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public string? CorreoElectronico { get; set; }
        public string? Contraseña { get; set; }
    }
}