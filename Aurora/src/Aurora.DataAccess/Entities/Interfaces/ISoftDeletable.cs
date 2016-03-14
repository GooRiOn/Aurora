namespace Aurora.DataAccess.Entities.Interfaces
{
    public interface ISoftDeletable
    {
        bool IsActive { get; }
        void Delete();
    }
}
