using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TostiElotes.Domain.Dtos
{
    public class ProductoCreateDTO
    {
        public int Id { get; set; }
        public  string Name { get; set; } = null!;
        public  string Description { get; set; } = null!;
        public decimal Price { get; set; }
    }
}