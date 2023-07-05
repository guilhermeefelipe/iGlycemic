using iGlycemic.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace iGlycemic.Infrastructure
{
    public class DbContextClass : DbContext
    {

        public DbContextClass(DbContextOptions<DbContextClass> contextOptions) : base(contextOptions)
        {
        }

        public DbSet<Usuario> Usuario { get; set; }
    }
}
