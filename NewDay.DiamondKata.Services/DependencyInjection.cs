namespace NewDay.DiamondKata.Services;

public static class DependencyInjection
{
    public static IServiceCollection AddDiamondKataServices(this IServiceCollection services) =>
        services.AddTransient<IDiamondGenerator, DiamondGenerator>();
}
