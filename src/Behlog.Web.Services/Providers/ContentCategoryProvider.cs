namespace Behlog.Web.Services;

/// <inheritdoc />
public class ContentCategoryProvider : IContentCategoryProvider
{
    private readonly IBehlogMediator _behlog;

    public ContentCategoryProvider(IBehlogMediator behlog)
    {
        _behlog = behlog ?? throw new ArgumentNullException(nameof(behlog));
    }
    
    /// <inheritdoc />
    public async Task<SelectListViewModel> GetSelectListAsync(Guid langId, Guid contentTypeId)
    {
        langId.ThrowIfGuidIsEmpty(new BehlogInvalidEntityIdException(nameof(Language)));
        contentTypeId.ThrowIfGuidIsEmpty(new BehlogInvalidEntityIdException(nameof(ContentType)));

        var query = new QueryContentCategoryByContentType(contentTypeId, null, langId);
        var result = await _behlog.PublishAsync(query).ConfigureAwait(false);

        if (result is null) return null;

        if (!result.Any()) return new SelectListViewModel();

        return new SelectListViewModel(result.Select(
                _ => new SelectListItemViewModel(_.Title, _.Id.ToString())).ToList()
        );
    }
    
    /// <inheritdoc />
    public async Task<SelectListViewModel> GetSelectListAsync(Guid langId, string contentTypeName)
    {
        langId.ThrowIfGuidIsEmpty(new BehlogInvalidEntityIdException(nameof(Language)));
        if (contentTypeName.IsNullOrEmpty()) throw new ArgumentNullException(nameof(contentTypeName));

        var query = new QueryContentCategoryByContentType(null, contentTypeName, langId);
        var result = await _behlog.PublishAsync(query).ConfigureAwait(false);

        if (result is null) return null;

        if (!result.Any()) return new SelectListViewModel();

        return new SelectListViewModel(result.Select(
                _ => new SelectListItemViewModel(_.Title, _.Id.ToString())).ToList()
        );
    }

    
    /// <inheritdoc />
    public async Task<SelectListViewModel> GetSelectListAsync(string langCode, string contentTypeName)
    {
        if (langCode.IsNullOrEmpty()) throw new ArgumentNullException(nameof(langCode));
        if (contentTypeName.IsNullOrEmpty()) throw new ArgumentNullException(nameof(contentTypeName));

        var lang = await _behlog.PublishAsync(new QueryLanguageByCode(langCode)).ConfigureAwait(false);
        lang.ThrowExceptionIfReferenceIsNull($"The language with code: '{langCode}' not found.");

        return await GetSelectListAsync(lang.Id, contentTypeName);
    }
}