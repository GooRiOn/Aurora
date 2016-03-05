using Aurora.Infrastructure.Entities.Interfaces;

namespace Aurora.Infrastructure.Entities
{
    public abstract class InternalEntity : IInternalEntity, ISoftDeletable
    {
        public bool IsActive { get; private set; }

        void ISoftDeletable.Delete()
        {
            this.IsActive = false;
        }
    }
}
