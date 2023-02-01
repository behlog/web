namespace Behlog.Web.Services;

/// <inheritdoc />
public class LanguageProvider : ILanguageProvider
{
    private readonly IBehlogMediator _behlog;

    public LanguageProvider(IBehlogMediator behlog)
    {
        _behlog = behlog ?? throw new ArgumentNullException(nameof(behlog));
    }
    
    public async Task<SelectListViewModel> GetSelectListAsync(EntityStatus? status = null)
    {
        throw new NotImplementedException();
    }
}