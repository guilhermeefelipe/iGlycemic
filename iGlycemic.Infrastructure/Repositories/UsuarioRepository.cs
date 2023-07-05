using iGlycemic.Core.Models;
using iGlycemic.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iGlycemic.Infrastructure.Repositories
{
    public class UsuarioRepository : GenericRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(DbContextClass dbContext) : base(dbContext)
        {

        }
    }
}
