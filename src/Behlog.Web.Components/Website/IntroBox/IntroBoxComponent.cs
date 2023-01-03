using Behlog.Cms.Commands;
using Behlog.Core;

namespace Behlog.Web.Components;

public class IntroBoxComponent : IIntroBoxComponent
{
    private const string _componentType = "introbox";
    private const string _category = "boxes";
    private const string _author = "ImanN";
    private const string _authorEmail = "imun22@gmail.com";
    private const string _keywords = "intro; info; summary";

    public string ComponentType => _componentType;
    public string Category => _category;
    public string Author => _author;
    public string AuthorEmail => _authorEmail;
    public string Keywords => _keywords;

    private readonly IBehlogMediator _behlog;

    public IntroBoxComponent(IBehlogMediator behlog)
    {
        _behlog = behlog ?? throw new ArgumentNullException(nameof(behlog));
    }
    
    public async Task InstallAsync(
        Guid websiteId, Guid langId, string name, string title, Guid? parentId, 
        string? description = null, bool isRtl = false, string? viewPath = null)
    {
        var command = new UpsertComponentCommand
        {
            WebsiteId = websiteId,
            Author = _author,
            Category = _category,
            Name = name,
            Title = title,
            ComponentType = _componentType,
            AuthorEmail = _authorEmail,
            Keywords = _keywords,
            Description = description,
            IsRtl = isRtl,
            LangId = langId,
            ParentId = parentId,
            ViewPath = viewPath
        };

        var component = await _behlog.PublishAsync(command).ConfigureAwait(false);
        if (component.HasError)
        {
            Console.WriteLine($"Component '{component.Value.Name}' install error with message : {component.Errors.ToString()}");
            return;
        }
        
        Console.WriteLine($"Component '{component.Value.Name}' created successfully.");
    }

    public Task<UpdateIntroBoxViewModel> UpdateAsync(UpdateIntroBoxViewModel model, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<IntroBoxViewModel> LoadAsync(Guid websiteId, Guid langId, string name, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<IntroBoxViewModel> LoadAsync(Guid websiteId, string langCode, string name, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}