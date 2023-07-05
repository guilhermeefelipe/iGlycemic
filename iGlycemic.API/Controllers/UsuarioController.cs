using FluentResults;
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
    public class UsuarioController : ControllerBase
    {
        public readonly IUsuarioService _usuarioService;
        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        [Authorize]
        [Route("ListaUsuarios")]
        public Response ListaUsuarios()
        {
            return new Response(_usuarioService.ListUsuarios().ToArray());
        }

        [HttpPost]
        [Route("Insert")]
        public Result CriarUsuario(UsuarioDTO dto)
        {
            return _usuarioService.CreateUsuario(dto);
        }
    }
}