using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TostiElotes.Domain.Dtos
{
    public class OrderCreateDTO
    {

        public int Id { get; set; }
        public string? CustomerName { get; set; }
        public string? Address { get; set; }
        public int Quantity { get; set; }
        public int IdProduct { get; set; }
        public int IdUser { get; set; }

    }
    
}