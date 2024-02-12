using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TostiElotes.Domain.Dtos
{
  public class ProductoCreateDTO
  {

    [Required(ErrorMessage = "La categoría es obligatoria.")]
    public string Categoria { get; set; } = null!;

    [Required(ErrorMessage = "La clave del producto es obligatoria.")]
    public string ClaveProducto { get; set; } = null!;

    [Required(ErrorMessage = "El nombre del producto es obligatorio.")]
    public string NombreProducto { get; set; } = null!;

    public string? Descripcion { get; set; }

    [Required(ErrorMessage = "La imagen del producto es obligatoria.")]
    public string ImagenProducto { get; set; } = null!;

    [Required(ErrorMessage = "El Tamaño del producto es obligatoria.")]
    public string? Tamano { get; set; }

    public string? Sabor { get; set; }

    [Required(ErrorMessage = "El precio es obligatorio.")]
    [Range(0, double.MaxValue, ErrorMessage = "El precio debe ser mayor o igual a cero.")]
    public decimal Precio { get; set; }

    [Required(ErrorMessage = "La disponibilidad es obligatoria.")]
    [Range(0, 99, ErrorMessage = "La disponibilidad debe ser mayor o igual a cero.")]
    public int Disponibilidad { get; set; }

    public string? PromocionesDescuentos { get; set; }

    public int? IdPuesto { get; set; }

  }
  public class ProductoDTO
  {
    public int Id { get; set; }

    public string Categoria { get; set; } = null!;

    public string ClaveProducto { get; set; } = null!;

    public string NombreProducto { get; set; } = null!;

    public string? Descripcion { get; set; }

    public string ImagenProducto { get; set; } = null!;

    public string? Tamano { get; set; }

    public string? Sabor { get; set; }

    public decimal Precio { get; set; }

    public int Disponibilidad { get; set; }

    public string? PromocionesDescuentos { get; set; }

    public int? IdPuesto { get; set; }
  }
}