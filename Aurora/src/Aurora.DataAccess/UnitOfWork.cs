using System;
using System.Threading.Tasks;
using Aurora.DataAccess.Interfaces;
using Aurora.Infrastructure.Interfaces;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Storage;


namespace Aurora.DataAccess
{
    public class UnitOfWork : IUnitOfWork, IContextGetter
    {
        private readonly AuroraContext _context;
        private readonly IRelationalTransaction _transaction;

        private bool _isCommited;
        private bool _isDisposed;

        public UnitOfWork(AuroraContext context)
        {
            _context = context;
            _transaction = context.Database.BeginTransaction();
        }

        public int Commit()
        {
            if (_isCommited)
                throw new NotSupportedException("Cannot commit commited UOW");
            if (_isDisposed)
                throw new NotSupportedException("Cannot commit disposed UOW");

            var result = _context.SaveChanges();
            _isCommited = true;

            return result;
        }

        public async Task<int> CommitAsync()
        {
            if (_isCommited)
                throw new NotSupportedException("Cannot commit commited UOW");
            if (_isDisposed)
                throw new NotSupportedException("Cannot commit disposed UOW");

             var result = await _context.SaveChangesAsync();

            _transaction.Commit();

            _isCommited = true;

            return result;
        }

        public void Dispose()
        {
            if (_isDisposed == false)
            {
                _context.Dispose();
                _isDisposed = true;
                _transaction.Dispose();
            }
        }

        AuroraContext IContextGetter.Context => _context;
    }
}
