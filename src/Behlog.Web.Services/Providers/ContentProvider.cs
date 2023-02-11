using Behlog.Cms.Query;

namespace Behlog.Web.Services;

/// <inheritdoc />
public class ContentProvider : IContentProvider
{
    private readonly IBehlogMediator _behlog;

    public ContentProvider(IBehlogMediator behlog) {
        _behlog = behlog ?? throw new ArgumentNullException(nameof(behlog));
    }

    /// <inheritdoc /> 
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


	/// <inheritdoc /> 
	public async Task<ContentIndexViewModel> GetIndexAsync(
        Guid websiteId, string langCode, string contentTypeName, int page, int pageSize) {

		websiteId.ThrowIfGuidIsEmpty(new BehlogInvalidEntityIdException(nameof(Website)));

		if (contentTypeName.IsNullOrEmptySpace())
			throw new ArgumentNullException(nameof(contentTypeName));

		if (langCode.IsNullOrEmptySpace())
			throw new ArgumentNullException(nameof(langCode));

		var langId = BehlogSupportedLanguages.GetIdByCode(langCode);
        var contentType = await _behlog.PublishAsync(
            new QueryContentTypeBySystemName(contentTypeName, langId)).ConfigureAwait(false);

        var model = ContentIndexViewModel.New(
            langId, langCode, BehlogSupportedLanguages.GetTitleByCode(langCode));

        var queryOptions = QueryOptions.New()
            .WithPageNumber(page).WithPageSize(pageSize)
            .WillOrderBy("PublishDate").WillOrderDesc();

        model.WithContents(
            await _behlog.PublishAsync(
                new QueryPublishedContentsByContentTypeName(
                    websiteId, langCode, contentTypeName, queryOptions)).ConfigureAwait(false));
        model.WithCategories(
            await _behlog.PublishAsync(
                new QueryContentCategoryByContentType(contentType.Id, null, langId)).ConfigureAwait(false));

        //model.WithTags TOD : read tags

        return await Task.FromResult(model);
	}
}