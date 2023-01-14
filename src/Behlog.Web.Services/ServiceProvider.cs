

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceProvider
{

    /// <summary>
    /// Adds Behlog's ready to use Services to done related commands easily.
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddBehlogWebServices(this IServiceCollection services)
    {
        services.AddScoped<IUserIdentityService, UserIdentityService>();
        services.AddScoped<IContentProvider, ContentProvider>();

        return services;
    }
}