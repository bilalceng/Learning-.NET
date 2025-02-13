using WebApplication1.models;

namespace WebApplication1.di;

public static class DbRepoServiceCollectionExtensions
{
    public static IServiceCollection AddDbRepo(this IServiceCollection services)
    {
        services.AddSingleton<Repository>();
        services.AddTransient<DataContext>();
        return services;
    }
}