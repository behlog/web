namespace Behlog.Web.Services;

/// <inheritdoc />
public class ContentProvider : IContentProvider
{
    private readonly IBehlogMediator _behlog;

    public ContentProvider(IBehlogMediator behlog) {
        _behlog = behlog ?? throw new ArgumentNullException(nameof(behlog));
    }

    public async Task<ContentDetailsViewModel> GetDetailsAsync(
        Guid websiteId, string contentTypeName, string slug, string langCode) {
        websiteId.ThrowIfGuidIsEmpty(new BehlogInvalidEntityIdException(nameof(Website)));
        if (contentTypeName.IsNullOrEmptySpace())
            throw new ArgumentNullException(nameof(contentTypeName));
        if (slug.IsNullOrEmptySpace())
            throw new ArgumentNullException(nameof(slug));
        if (langCode.IsNullOrEmptySpace())
            throw new ArgumentNullException(nameof(langCode));

        var langId = BehlogSupportedLanguages.GetIdByCode(langCode);
        var model = new ContentDetailsViewModel();
        
        var content = await _behlog.PublishAsync(
            new QueryContentByContentTypeAndSlug(websiteId, slug, null, contentTypeName, langId));
        content.ThrowExceptionIfReferenceIsNull(nameof(content));
        model.Content = new ContentViewModel(content);

        var categories = await _behlog.PublishAsync(
            new QueryContentCategoryByContentType(null, contentTypeName, langId));
        model.Categories = categories?.Select(_ => new ContentCategoryViewModel(_)).ToList();

        var latestContents = await _behlog.PublishAsync(
            new QueryLatestContentsByContentType(websiteId, null, contentTypeName, 4));
        model.RelatedContents = latestContents?.Select(_ => new ContentViewModel(_)).ToList();

        return await Task.FromResult(model);
    }
}