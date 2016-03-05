namespace Aurora.Infrastructure.DependencyInjection.Initerfaces
{
    public interface ICustomDependencyResolver
    {
        TResolved Resolve<TResolved>();
        TResolved Resolve<TResolved, TOverride>(string parameterName, TOverride @override);
        TResolved Resolve<TResolved, TOverride0, TOverride1>(string parameterName1, string parameterName2, TOverride0 @override0, TOverride1 @override1);
    }
}