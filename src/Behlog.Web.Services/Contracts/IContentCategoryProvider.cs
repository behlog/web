namespace Behlog.Web.Services.Contracts;

/// <summary>
/// Provides services to query <see cref="ContentCategory"/> with it's related data for the Web.
/// </summary>
public interface IContentCategoryProvider
{

    Task<SelectListViewModel> GetSelectListAsync(Guid langId, Guid contentTypeId);
    
    Task<SelectListViewModel> GetSelectListAsync(Guid langId, string contentTypeName);

    Task<SelectListViewModel> GetSelectListAsync(string langCode, string contentTypeName);
}