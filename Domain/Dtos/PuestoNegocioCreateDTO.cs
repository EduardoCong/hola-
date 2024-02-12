using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TostiElotes.Domain.Dtos
{

    public class PuestoNegocioCreateDTO
    {
        [Required(ErrorMessage = "El campo NombreNegocio es obligatorio.")]
        public string NombreNegocio { get; set; } = null!;

        [Required(ErrorMessage = "El campo FotosRepresentativas es obligatorio.")]
        public string FotosRepresentativas { get; set; } = null!;

        [Required(ErrorMessage = "El campo UbicacionExacta es obligatorio.")]
        public string UbicacionExacta { get; set; } = null!;

        [Required(ErrorMessage = "El campo HorarioAtencion es obligatorio.")]
        public string HorarioAtencion { get; set; } = null!;

        [Required(ErrorMessage = "El campo MetodosPagoAceptados es obligatorio.")]
        public string MetodosPagoAceptados { get; set; } = null!;
        public string? InformacionAdicional { get; set; }
        public int? IdVendedor { get; set; }
    }

    public class PuestoNegocioDTO
    {
        public int Id { get; set; }

        public string NombreNegocio { get; set; } = null!;

        public string FotosRepresentativas { get; set; } = null!;

        public string UbicacionExacta { get; set; } = null!;

        public string HorarioAtencion { get; set; } = null!;

        public string MetodosPagoAceptados { get; set; } = null!;

        public string? InformacionAdicional { get; set; }

        public int? IdVendedor { get; set; }
    }
}