namespace Behlog.Web.Services.Contracts;

/// <summary>
/// Provides services to query <see cref="ContentType"/> with it's related data for the web.
/// </summary>
public interface IContentTypeProvider
{

    
    Task<SelectListViewModel> GetSelectListAsync(
        string langCode, EntityStatus? status = null, CancellationToken cancellationToken = default);
}