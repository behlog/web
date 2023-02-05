

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceProvider
{

    /// <summary>
    /// Adds ready to use Services to be used in other Behlog-based web projects.
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddBehlogWebServices(this IServiceCollection services)
    {
        services.AddScoped<IUserIdentityService, UserIdentityService>();
        services.AddScoped<IContentProvider, ContentProvider>();
        services.AddScoped<IContentTypeProvider, ContentTypeProvider>();
        services.AddScoped<ILanguageProvider, LanguageProvider>();
        services.AddScoped<IContentCategoryProvider, ContentCategoryProvider>();

        return services;
    }
}