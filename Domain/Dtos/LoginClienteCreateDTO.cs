using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TostiElotes.Domain.Dtos
{
    public class LoginClienteCreateDTO
    {

    public int? IdCliente { get; set; }

    public string NomUsuario { get; set; } = null!;

    public string Contraseña { get; set; } = null!;
    }

    public class LoginClienteDTO
    {
        public int IdUsuario { get; set; }

    public int? IdCliente { get; set; }

    public string NomUsuario { get; set; } = null!;

    public string Contraseña { get; set; } = null!;
    }
}