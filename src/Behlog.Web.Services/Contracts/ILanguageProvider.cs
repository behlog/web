namespace Behlog.Web.Services.Contracts;

/// <summary>
/// Provides services to query <see cref="Language"/> with it's related data for the web.
/// </summary>
public interface ILanguageProvider
{

    Task<SelectListViewModel> GetSelectListAsync(
        EntityStatus? status = null, CancellationToken cancellationToken = default);
}