using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TostiElotes.Domain.Entities
{

    public class ClienteInfo
    {
        public int IdCliente { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Email { get; set; }
        public string? Telefono { get; set; }
        public string? Direccion { get; set; }
        public string? CorreoElectronico { get; set; }
        public string? Contraseña { get; set; }
        public List<OrdenInfo>? Orden { get; set; }
    }

    public class OrdenInfo
    {
        public int IdOrden { get; set; }
        public DateTime? Fecha { get; set; }
        public int? IdCliente { get; set; }
        public int? IdVendedor { get; set; }
        public string? DireccionEnvio { get; set; }
        public string? DetallesPago { get; set; }
        public List<object>? DetallesOrden { get; set; }
    }

}