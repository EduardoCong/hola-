using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TostiElotes.Domain.Dtos
{
    public class EstadoEsntregaDTO
    {

        public int IdEstado { get; set; }

        public int? IdOrden { get; set; }

        public string? Estado { get; set; }

        public string? Comentarios { get; set; }

    }

}