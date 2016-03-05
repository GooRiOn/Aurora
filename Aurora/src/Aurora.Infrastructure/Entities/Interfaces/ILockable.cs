namespace Aurora.Infrastructure.Entities.Interfaces
{
    public interface ILockable
    {
        bool IsLocked { get; }
        void Lock();
        void Unlock();
    }
}