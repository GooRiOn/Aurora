using Aurora.Infrastructure.Entities;

namespace Aurora.Domain.DomainServices.Interfaces
{
    public interface IUserDomainService : IEntityService<UserEntity, string>
    {
        int Test();
    }
}