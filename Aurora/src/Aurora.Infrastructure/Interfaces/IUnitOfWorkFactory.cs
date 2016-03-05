namespace Aurora.Infrastructure.Interfaces
{
    public interface IUnitOfWorkFactory<out TUnitOfWork>
    {
        TUnitOfWork Get();
    }

    public interface IUnitOfWorkFactory : IUnitOfWorkFactory<IUnitOfWork>
    {
    }
}
