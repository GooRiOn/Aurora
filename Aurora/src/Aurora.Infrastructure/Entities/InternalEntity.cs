using Aurora.Infrastructure.Entities.Interfaces;

namespace Aurora.Infrastructure.Entities
{
    public class InternalEntity : IInternalEntity<int>, ISoftDeletable
    {
        public int Id { get; set; }
        public bool IsActive { get; private set; }

        void ISoftDeletable.Delete()
        {
            this.IsActive = false;
        }
    }
}
