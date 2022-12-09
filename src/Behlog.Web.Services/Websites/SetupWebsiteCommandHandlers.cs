//using Behlog.Core;
//using Behlog.Cms.Seed;
//using Behlog.Extensions;
//using Behlog.Web.Models;
//using Behlog.Cms.Contracts;

//namespace Behlog.Web.Services;


//public class SetupWebsiteCommandHandlers :
//    IBehlogCommandHandler<WebsiteSetupModel, WebsiteSetupModel>
//{
//    private readonly ICmsSetup _setup;
    
//    public SetupWebsiteCommandHandlers(ICmsSetup setup)
//    {
//        _setup = setup ?? throw new ArgumentNullException(nameof(setup));
//    }
    
//    public async Task<WebsiteSetupModel> HandleAsync(
//        WebsiteSetupModel model, CancellationToken cancellationToken = default)
//    {
//        model.ThrowExceptionIfArgumentIsNull(nameof(model));
//        //if (model.HasError)
//        //{
//        //    return model;
//        //}

//        var seedData = new WebsiteSeedData
//        {
//            Name = model.Name?.Trim()!,
//            Title = model.Title?.Trim().CorrectYeKe()!,
//            Url = model.Url?.Trim()!,
//            Email = model.Email?.Trim().ToEnglishNumbers()!,
//            Description = model.Description?.CorrectYeKe()!,
//            Keywords = model.Keywords?.Trim().CorrectYeKe()!,
//            CopyrightText = model.CopyrightText?.Trim().CorrectYeKe()!,
//            LangCode = model.LangCode
//        };
        
//        await _setup.SetupAsync(seedData, cancellationToken).ConfigureAwait(false);
        
//        //model.Succeed();
//        return model;
//    }
//}