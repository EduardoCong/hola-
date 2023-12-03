using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TostiElotes.Domain.Dtos
{
    public class OrdenCreateDTO
    {
        [Required(ErrorMessage = "El campo IdCarrito es obligatorio.")]
        public int? IdCarrito { get; set; }

        public string? Estado { get; set; }

        [Required(ErrorMessage = "El campo RepartidorId es obligatorio.")]
        public int? RepartidorId { get; set; }

    }

    public class OrdenDTO
    {
        public int IdOrden { get; set; }

        public int? IdCarrito { get; set; }

        public string? Estado { get; set; }

        public int? RepartidorId { get; set; }

        public DateTime? FechaCreacion { get; set; }

        public DateTime? FechaActualizacion { get; set; }
    }
}