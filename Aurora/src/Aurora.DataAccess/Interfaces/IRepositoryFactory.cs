using Aurora.Infrastructure.Interfaces;

namespace Aurora.DataAccess.Interfaces
{
    public interface IRepositoryFactory<out TRepo>
    {
        TRepo Get(IUnitOfWork unitOfWork);
    }
}