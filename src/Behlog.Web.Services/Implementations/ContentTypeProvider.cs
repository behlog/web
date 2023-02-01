namespace Behlog.Web.Services;

/// <inheritdoc />
public class ContentTypeProvider : IContentTypeProvider
{
    private readonly IBehlogMediator _behlog;

    public ContentTypeProvider(IBehlogMediator behlog)
    {
        _behlog = behlog ?? throw new ArgumentNullException(nameof(behlog));
    }
    
    public async Task<SelectListViewModel> GetSelectListAsync(string langCode, EntityStatus? status = null)
    {
        throw new NotImplementedException();
    }
}