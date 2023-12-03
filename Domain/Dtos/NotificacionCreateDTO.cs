using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TostiElotes.Domain.Dtos
{
    public class NotificacionCreateDTO
    {

    public int? IdVendedor { get; set; }

    public string Mensaje { get; set; } = null!;

    public DateTime Fecha { get; set; }

    public string Estado { get; set; } = null!;
    }
    public class NotificacionDTO
    {
        public int IdNotificacion { get; set; }

    public int? IdVendedor { get; set; }

    public string Mensaje { get; set; } = null!;

    public DateTime Fecha { get; set; }

    public string Estado { get; set; } = null!;
    }
}