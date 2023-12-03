using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TostiElotes.Domain.Dtos
{
    public class DetallesCarritoCreateDTO
    {

    [Required(ErrorMessage = "El campo IdCarrito es obligatorio.")]
    public int? IdCarrito { get; set; }

    [Required(ErrorMessage = "El campo IdProducto es obligatorio.")]
    public int? IdProducto { get; set; }

    [Required(ErrorMessage = "El campo Cantidad es obligatorio.")]
    [Range(1, 10, ErrorMessage = "El campo Cantidad debe ser mayor que cero.")]
    public int? Cantidad { get; set; }

    public string? Extras { get; set; } = null;
    }

    public class DetallesCarritoDTO
    {
        public int IdDetalle { get; set; }

    public int? IdCarrito { get; set; }

    public int? IdProducto { get; set; }

    public int? Cantidad { get; set; }

    public string? Extras { get; set; }
    }
}