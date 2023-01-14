namespace Behlog.Web.Services.Contracts;

/// <summary>
/// Provide services to query <see cref="Content"/> with it's related details.
/// </summary>
public interface IContentProvider
{

    /// <summary>
    /// Gets Content with Latest Contents and categories assosiated to it's ContentType.
    /// </summary>
    Task<ContentDetailsViewModel> GetDetailsAsync(
        Guid websiteId, string contentTypeName, string slug, string langCode);

}
