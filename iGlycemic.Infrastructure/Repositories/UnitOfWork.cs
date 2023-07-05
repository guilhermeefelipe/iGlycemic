using FluentResults;
using iGlycemic.Core.Attributes;
using iGlycemic.Core.Interfaces;
using iGlycemic.Core.Validation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace iGlycemic.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContextClass _dbContext;
        public IUsuarioRepository Usuario { get; }

        public UnitOfWork(DbContextClass dbContext,
                            IUsuarioRepository usuarioRepository)
        {
            _dbContext = dbContext;
            Usuario = usuarioRepository;
        }

        public void Save()
        {
            foreach (var entry in _dbContext.ChangeTracker.Entries().Where(o => o.State == EntityState.Added || o.State == EntityState.Modified ||
                                                                                o.State == EntityState.Deleted))
            {

                ICoreValidation? obj = entry.Entity as ICoreValidation;

                if (entry.State == EntityState.Added || entry.State == EntityState.Modified)
                {
                    FluentResults.Result result = obj.Validate();

                    if (result.IsFailed)
                        Result.Fail(result.Errors[0].Message);


                    ForceCase.Apply(obj);
                }

                _dbContext.SaveChanges();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dbContext.Dispose();
            }
        }

    }
}
