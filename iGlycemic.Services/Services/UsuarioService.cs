using FluentResults;
using iGlycemic.Core.Interfaces;
using iGlycemic.Core.Models;
using iGlycemic.Infrastructure.Repositories;
using iGlycemic.Services.DTOs;
using iGlycemic.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Tracing;
using System.Transactions;

namespace iGlycemic.Services.Services
{
    public class UsuarioService : IUsuarioService
    {
        public IUnitOfWork Unit;


        public UsuarioService(IUnitOfWork unitOfWork)
        {
            Unit = unitOfWork;
        }

        public Result CreateUsuario(UsuarioDTO dto)
        {
            if (dto is null)
                return new Error("Dto inválida");
            
            var usuario = new Usuario
            {
               Nome = dto.Nome,
               Email = dto.Email,
               Senha = new TokenService().EncodePasswordToBase64(dto.Senha)
            };

            using (var scope = new TransactionScope())
            {
                Unit.Usuario.Insert(usuario);
                Unit.Save();

                scope.Complete();
            }

            return Result.Ok();

        }

        public IEnumerable<Usuario> ListUsuarios()
        {
            var usuarios = Unit.Usuario.GetAll();
            return usuarios;
        }
    }
}
