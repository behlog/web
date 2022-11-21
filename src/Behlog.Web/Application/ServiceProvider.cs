using Behlog.Web.Application;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceProvider
{

    public static void AddBehlogWebsite(this IServiceCollection services)
    {
        var website = getWebsite();
        services.AddSingleton<BehlogWebsite>(website);
    }


    private static BehlogWebsite getWebsite()
    {
        var website = new BehlogWebsite();
        website.SetTheme("default");
        return website;
    }
}