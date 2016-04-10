using System;
using System.Threading.Tasks;

namespace Aurora.Infrastructure.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        int Commit();
        Task<int> CommitAsync();
        void Rollback();
    }
}