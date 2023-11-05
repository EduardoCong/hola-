using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TostiElotes.Domain.Dtos;
namespace TostiElotes.Domain.Dtos
{
    public class OrderCreateDTO
    {


        public DateTime? Fecha { get; set; }

        public int? IdCliente { get; set; }

        public int? IdVendedor { get; set; }

        public string? DireccionEnvio { get; set; }

        public string? DetallesPago { get; set; }
    }

}