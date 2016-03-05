namespace Aurora.DataAccess.Interfaces
{
    public interface IContextGetter
    {
        AuroraContext Context { get; }
    }
}