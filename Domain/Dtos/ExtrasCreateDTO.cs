using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TostiElotes.Domain.Dtos
{
    public class ExtraCreateDTO
    {

        [Required(ErrorMessage = "El campo idproducto es obligatorio.")]
        public virtual int IdProducto { get; set; }

        [Required(ErrorMessage = "El campo Nombre es obligatorio.")]
        public string NombreExtra { get; set; } = null!;

        [Required(ErrorMessage = "El campo DescripcionExtra es obligatorio.")]
        public string? DescripcionExtra { get; set; }

        [Required(ErrorMessage = "El campo PrecioExtra es obligatorio.")]
        public decimal PrecioExtra { get; set; }

    }
    public class ExtraDTO
    {
        public int Id { get; set; }

        public int IdProducto { get; set; }

        public string NombreExtra { get; set; } = null!;

        public string? DescripcionExtra { get; set; }

        public decimal PrecioExtra { get; set; }
    }
}