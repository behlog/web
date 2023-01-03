using Behlog.Web.Components;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceProvider
{
    
    /// <summary>
    /// Adds Behlog Default WebComponents to the ServiceCollection.
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddDefaultBehlogWebComponents(this IServiceCollection services)
    {
        services.AddScoped<IImageSliderComponent, ImageSliderComponent>();
        services.AddScoped<IIntroBoxComponent, IntroBoxComponent>();

        return services;
    }
}