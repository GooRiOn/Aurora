using Aurora.Infrastructure.Entities.Interfaces;

namespace Aurora.Infrastructure.Entities
{
    public abstract class InternalEntity : IInternalEntity<int>, ISoftDeletable
    {
        public int Id { get; set; }
        public bool IsActive { get; private set; }

        void ISoftDeletable.Delete()
        {
            this.IsActive = false;
        }
    }
}
