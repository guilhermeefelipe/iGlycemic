using iGlycemic.Core.Interfaces;
using iGlycemic.Core.Models;
using iGlycemic.Services.DTOs;
using iGlycemic.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iGlycemic.Services.Services
{
    public class AuthService : IAuthService
    {
        public IUnitOfWork Unit;

        public AuthService(IUnitOfWork unitOfWork)
        {
            Unit = unitOfWork;
        }
        public dynamic GerarToken(UsuarioDTO dto)
        {
            var psw = new TokenService().EncodePasswordToBase64(dto.Senha);
            var usuario = Unit.Usuario.Query(a => a.Email == dto.Email & a.Senha == psw).FirstOrDefault();

            if (usuario is null)
                throw new Exception("Usuario não encontrado");

            return new
            {
                token = TokenService.GenerateToken(usuario)
            };
        }
    }
}
