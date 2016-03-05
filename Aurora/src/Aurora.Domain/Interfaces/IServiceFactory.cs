using Aurora.Infrastructure.Interfaces;

namespace Aurora.Domain.Interfaces
{
    public interface IServiceFactory<out TService>
    {
        TService Get(IUnitOfWork unitOfWork);
    }
}