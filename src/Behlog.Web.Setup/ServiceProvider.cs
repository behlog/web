using Behlog.Web.Core;
using Behlog.Web.Setup;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.FileProviders;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceProvider
{

    public static IMvcBuilder AddBehlogSetupArea(this IMvcBuilder builder)
    {
        var assembly = typeof(HomeController).Assembly;
        builder.AddApplicationPart(assembly)
            .AddRazorRuntimeCompilation(options =>
            {
                options.FileProviders.Add(new EmbeddedFileProvider(assembly));
            })
            .AddRazorOptions(engine =>
            {
            });
        
        return builder;
    }

    /// <summary>
    /// Adds Behlog Setup area routes.
    /// </summary>
    public static IEndpointRouteBuilder AddBehlogSetupRoutes(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapAreaControllerRoute(
            name: "setup",
            areaName: WebsiteAreaNames.Setup,
            pattern: "{area}/{controller=Home}/{action=Index}/{id?}");

        return endpoints;
    }
}