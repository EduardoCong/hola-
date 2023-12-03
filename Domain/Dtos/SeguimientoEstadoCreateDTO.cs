using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TostiElotes.Domain.Dtos
{
    public class SeguimientoEstadoCreateDTO
    {

    public int? IdOrden { get; set; }

    public string? EstadoActual { get; set; }

    }

     public class SeguimientoEstadoDTO
    {
        public int IdSeguimiento { get; set; }

    public int? IdOrden { get; set; }

    public string? EstadoAnterior { get; set; }

    public string? EstadoActual { get; set; }

    public DateTime? FechaCambio { get; set; }
    }
}