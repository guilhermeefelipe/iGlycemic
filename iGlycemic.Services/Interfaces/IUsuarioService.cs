using FluentResults;
using iGlycemic.Core.Models;
using iGlycemic.Services.DTOs;

namespace iGlycemic.Services.Interfaces
{
    public interface IUsuarioService
    {
        Result CreateUsuario(UsuarioDTO usuario);

        IEnumerable<Usuario> ListUsuarios();

        //Task<ProductDetails> GetProductById(int productId);

        //Task<bool> UpdateProduct(ProductDetails productDetails);

        //Task<bool> DeleteProduct(int productId);
    }
}
