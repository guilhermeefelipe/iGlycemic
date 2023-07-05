using iGlycemic.Core.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iGlycemic.Services.DTOs
{
    public class UsuarioDTO
    {
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Nome { get; set; }

    }
}
