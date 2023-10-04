using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TostiElotes.Domain.Dtos
{
    public class UsuarioCreateDTO
    {
        public int id { get; set; }

        public string? first_Name { get; set; }

        public string? last_Name { get; set; }

        public string? email { get; set; }

    }
}