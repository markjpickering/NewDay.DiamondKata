namespace NewDay.DiamondKata.Console;

internal class Program
{
    public static void Main(string[] args) =>
        ConfigureServices(new ServiceCollection())
            .BuildServiceProvider()
            .GetRequiredService<Application>()
            .Run(args);

    public static IServiceCollection ConfigureServices(IServiceCollection services) =>
        services
            .AddSingleton<Application, Application>()
            .AddDiamondKataServices();    
}
