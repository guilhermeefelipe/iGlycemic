using iGlycemic.Services.DTOs;

namespace iGlycemic.Services.Interfaces
{
    public interface IAuthService
    {
        dynamic GerarToken(UsuarioDTO usuario);

    }
}
