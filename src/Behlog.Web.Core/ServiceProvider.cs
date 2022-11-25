using Behlog.Web.Core;


namespace Microsoft.Extensions.DependencyInjection;


public static class ServiceProvider
{

    public static IServiceCollection AddBehlogWebCore(
        this IServiceCollection services, string themeName = "default")
    {
        var website = getWebsite(themeName);
        services.AddSingleton<BehlogWebsite>(website);

        return services;
    }
    
    private static BehlogWebsite getWebsite(string theme)
    {
        var website = new BehlogWebsite();
        website.SetTheme(theme);
        return website;
    }
}