using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TostiElotes.Domain.Dtos
{
    public class LoginVendedorCreateDTO
    {

        public int? IdVendedor { get; set; }

        public string Usuario { get; set; } = null!;

        public string Contraseña { get; set; } = null!;
    }
    public class LoginVendedorDTO
    {
        public int IdCredencial { get; set; }

        public int? IdVendedor { get; set; }

        public string Usuario { get; set; } = null!;

        public string Contraseña { get; set; } = null!;
    }
}