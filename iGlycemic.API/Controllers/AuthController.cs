using iGlycemic.Core.Models;
using iGlycemic.Services.DTOs;
using iGlycemic.Services.Interfaces;
using iGlycemic.Services.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace UnitOfWorkDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        [Route("Token")]
        public dynamic GerarToken(UsuarioDTO dto)
        {
            return _authService.GerarToken(dto);
        }
    }
}