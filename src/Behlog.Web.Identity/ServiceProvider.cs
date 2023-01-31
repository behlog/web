using Behlog.Web.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.FileProviders;

namespace Microsoft.Extensions.DependencyInjection;


public static class ServiceProvider
{

    public static IMvcBuilder AddBehlogIdentityArea(this IMvcBuilder builder)
    {
        var assembly = typeof(AccountController).Assembly;
        builder.AddApplicationPart(assembly)
            .AddRazorRuntimeCompilation(options =>
            {
                options.FileProviders.Add(new EmbeddedFileProvider(assembly));
            });
        
        
        return builder;
    }

    /// <summary>
    /// Adds Behlog Identity area routes.
    /// </summary>
    public static IEndpointRouteBuilder AddBehlogIdentityRoutes(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapAreaControllerRoute(
            name: "identity",
            areaName: WebsiteAreaNames.Identity,
            pattern: "{area}/{controller=Home}/{action=Index}/{id?}");

        return endpoints;
    }
    
}