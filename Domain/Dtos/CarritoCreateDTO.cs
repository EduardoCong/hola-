using System.ComponentModel.DataAnnotations;


namespace TostiElotes.Domain.Dtos
{
    public class CarritoCreateDTO
    {
        [Required(ErrorMessage = "El campo IdCliente es obligatorio.")]
        public int? IdCliente { get; set; }

        [Required(ErrorMessage = "El campo MetodoEntrega es obligatorio.")]
        public string? MetodoEntrega { get; set; }
    }

    public class CarritoDTO
    {
        public int IdCarrito { get; set; }

        public int? IdCliente { get; set; }

        public string? Estado { get; set; }

        public decimal? Total { get; set; }

        public string? MetodoEntrega { get; set; }
    }
}