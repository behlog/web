using Behlog.Web.Core;


namespace Microsoft.Extensions.DependencyInjection;


public static class ServiceProvider
{

    public static IServiceCollection AddBehlogWebCore(this IServiceCollection services)
    {
        //var website = getWebsite(themeName);
        //services.AddSingleton<BehlogWebsite>(website);

        return services;
    }


    public static IServiceCollection AddBehlogWebsite(this IServiceCollection services, BehlogWebsite website)
    {
        services.AddSingleton<BehlogWebsite>(website);
        return services;
    }
    
    private static BehlogWebsite getWebsite(string theme)
    {
        var website = new BehlogWebsite();
        website.WithTheme(theme);
        return website;
    }
}