namespace Aurora.Infrastructure.Interfaces
{
    public interface IUnitOfWorkFactory<out TUnitOfWork>
    {
        TUnitOfWork Get(bool isReadOnly = true);
    }

    public interface IUnitOfWorkFactory : IUnitOfWorkFactory<IUnitOfWork>
    {
    }
}
