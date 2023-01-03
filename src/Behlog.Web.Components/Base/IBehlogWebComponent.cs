namespace Behlog.Web.Components.Base;


public interface IBehlogWebComponent<TUpdateModel, TViewModel> 
    where TUpdateModel : UpdateWebComponentViewModel
    where TViewModel : WebComponentViewModel
{
    
    string ComponentType { get; }
    
    string Category { get; }
    
    string Author { get; }
    
    string AuthorEmail { get; }
    
    string Keywords { get; }

    
    Task InstallAsync(
        Guid websiteId, Guid langId, string name, string title, Guid? parentId,
        string? description = null, bool isRtl = false, string? viewPath = null);

    
    Task<TUpdateModel> UpdateAsync(TUpdateModel model, CancellationToken cancellationToken = default);

    
    Task<TViewModel> LoadAsync(
        Guid websiteId, Guid langId, string name, CancellationToken cancellationToken = default);

    
    Task<TViewModel> LoadAsync(
        Guid websiteId, string langCode, string name, CancellationToken cancellationToken = default);
}