namespace Behlog.Web.Services;

/// <inheritdoc />
public class ContentTypeProvider : IContentTypeProvider
{
    private readonly IBehlogMediator _behlog;

    public ContentTypeProvider(IBehlogMediator behlog)
    {
        _behlog = behlog ?? throw new ArgumentNullException(nameof(behlog));
    }

    public async Task<SelectListViewModel> GetSelectListAsync(
        string langCode, EntityStatus? status = null, CancellationToken cancellationToken = default)
    {
        var query = new QueryContentTypesByLangCode(langCode, status);
        var contentTypes = await _behlog.PublishAsync(query, cancellationToken).ConfigureAwait(false);

        return new SelectListViewModel(
            contentTypes.Items.Select(x => new SelectListItemViewModel(x.Title, x.Id.ToString()))
            );
    }
}