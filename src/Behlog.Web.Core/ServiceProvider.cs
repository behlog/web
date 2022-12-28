using Behlog.Core;
using Behlog.Web.Core;
using Behlog.Cms.Query;
using Behlog.Cms.Domain;

namespace Microsoft.Extensions.DependencyInjection;


public static class ServiceProvider
{

    public static IServiceCollection AddBehlogWebCore(this IServiceCollection services)
    {
        //var website = getWebsite(themeName);
        //services.AddSingleton<BehlogWebsite>(website);

        return services;
    }


    /// <summary>
    /// Adds Custom BehlogWebsite data to the ServiceCollection. 
    /// </summary>
    public static IServiceCollection AddBehlogWebsite(this IServiceCollection services, BehlogWebsite website)
    {
        services.AddSingleton<BehlogWebsite>(website);
        return services;
    }

    /// <summary>
    /// Adds The first <see cref="Website"/> found in the database as the
    /// Default BehlogWebsite to the ServiceCollection.
    /// </summary>
    public static async Task<IServiceCollection> AddBehlogDefaultWebsite(this IServiceCollection services)
    {
        var serviceProvider = services.BuildServiceProvider();
        var behlog = serviceProvider.GetRequiredService<IBehlogMediator>();
        var website = await behlog.PublishAsync(new QueryDefaultWebsite());
        
        var defaultWebsite = new BehlogWebsite()
            .WithId(website.Id)
            .WithName(website.Name)
            .WithTitle(website.Title)
            .WithDefaultLangId(website.DefaultLangId!.Value)
            .WithEmail(website.Email!)
            .WithKeywords(website.Keywords!)
            .WithOwnerUserId(website.OwnerUserId)
            .WithDescription(website.Description!)
            .WithUrl(website.Url!)
            .WithCopyrightText(website.CopyrightText!)
            //TODO: Add TemplateName to Website Domain model. 
            .WithTemplateName("default");
        
        services.AddSingleton<BehlogWebsite>(defaultWebsite);
        
        return services; 
    }
    
    
    private static BehlogWebsite getWebsite(string theme)
    {
        var website = new BehlogWebsite();
        website.WithTemplateName(theme);
        return website;
    }
}