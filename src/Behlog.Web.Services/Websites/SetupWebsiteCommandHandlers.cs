using Behlog.Cms.Contracts;
using Behlog.Cms.Seed;
using Behlog.Core;
using Behlog.Extensions;
using Behlog.Web.Models;

namespace Behlog.Web.Services;


public class SetupWebsiteCommandHandlers :
    IBehlogCommandHandler<WebsiteSetupModel, WebsiteSetupModel>
{
    private readonly ICmsSetup _setup;
    
    public SetupWebsiteCommandHandlers(ICmsSetup setup)
    {
        _setup = setup ?? throw new ArgumentNullException(nameof(setup));
    }
    
    public async Task<WebsiteSetupModel> HandleAsync(
        WebsiteSetupModel model, CancellationToken cancellationToken = default)
    {
        model.ThrowExceptionIfArgumentIsNull(nameof(model));
        if (model.HasError)
        {
            return model;
        }

        await _setup.SetupAsync(new WebsiteSeedData(), cancellationToken).ConfigureAwait(false);

        return model;
    }
}