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
        AuroraContext IContextGetter.Context => _context;

        private readonly AuroraContext _context;
        private readonly IRelationalTransaction _transaction;

        private bool _isCommited;
        private bool _isDisposed;
        private bool _isReadOnly;

        public UnitOfWork(AuroraContext context, bool isReadOnly)
        {
            _context = context;
            _isReadOnly = isReadOnly;

            if(!isReadOnly)
                _transaction = context.Database.BeginTransaction();
        }

        public int Commit()
        {
            if (_isCommited)
                throw new NotSupportedException("Cannot commit commited UOW");
            if (_isDisposed)
                throw new NotSupportedException("Cannot commit disposed UOW");
            if (_isReadOnly)
                throw new NotSupportedException("Cannot commit readonly UOW");


            var result = _context.SaveChanges();

            _transaction.Commit();

            _isCommited = true;

            return result;
        }

        public async Task<int> CommitAsync()
        {
            if (_isCommited)
                throw new NotSupportedException("Cannot commit commited UOW");
            if (_isDisposed)
                throw new NotSupportedException("Cannot commit disposed UOW");
            if (_isReadOnly)
                throw new NotSupportedException("Cannot commit readonly UOW");

            var result = await _context.SaveChangesAsync();

            _transaction.Commit();

            _isCommited = true;

            return result;
        }

        public void Rollback()
        {
            _transaction.Rollback();
        }

        public void Dispose()
        {
            if (_isDisposed == false)
            {
                _context.Dispose();
                _isDisposed = true;

                if(!_isReadOnly)
                    _transaction.Dispose();
            }
        }

        
    }
}
