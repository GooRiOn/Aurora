namespace Aurora.Infrastructure.Entities.Interfaces
{
    public interface ISoftDeletable
    {
        bool IsActive { get; }
        void Delete();
    }
}
