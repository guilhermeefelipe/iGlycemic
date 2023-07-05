using FluentResults;

namespace iGlycemic.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IUsuarioRepository Usuario { get; }

        void Save();
    }
}
