using Aurora.Infrastructure.Interfaces;

namespace Aurora.Domain.Interfaces
{
    public interface IDomainServiceFactory<out TService>
    {
        TService Get(IUnitOfWork unitOfWork);
    }
}