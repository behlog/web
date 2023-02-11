namespace Behlog.Web.Services.Contracts;

/// <summary>
/// Provide services to query <see cref="Content"/> with it's related details.
/// </summary>
public interface IContentProvider
{

    /// <summary>
    /// Get a Published Content with Latest Contents and categories assosiated to it's ContentType.
    /// </summary>
    Task<ContentDetailsViewModel> GetDetailsAsync(
        Guid websiteId, string contentTypeName, string slug, string langCode);

    /// <summary>
    /// Gets Latests Published <see cref="Content"/>(s) with pagination support
    /// based on ContentTypeName and LangCode.
    /// </summary>
    /// <param name="websiteId"></param>
    /// <param name="langCode"></param>
    /// <param name="contentTypeName"></param>
    /// <param name="page"></param>
    /// <param name="pageSize"></param>
    Task<ContentIndexViewModel> GetIndexAsync(
        Guid websiteId, string langCode, string contentTypeName, int page, int pageSize);

}
