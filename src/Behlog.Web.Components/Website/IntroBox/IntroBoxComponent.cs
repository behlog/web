using Behlog.Cms.Commands;
using Behlog.Cms.Query;
using Behlog.Core;
using Behlog.Extensions;
using Newtonsoft.Json;

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

    public async Task<UpdateIntroBoxViewModel> UpdateAsync(
        UpdateIntroBoxViewModel model, CancellationToken cancellationToken = default)
    {
        model.ThrowExceptionIfArgumentIsNull(nameof(model));

        var command = new UpsertComponentCommand
        {
            Attributes = JsonConvert.SerializeObject(model, Formatting.Indented),
            Author = _author,
            Category = _category,
            Description = model.Description,
            Keywords = _keywords,
            Name = model.Name,
            Title = model.Title,
            AuthorEmail = _authorEmail,
            IsRtl = model.IsRtl,
            ComponentType = _componentType,
            Files = model.Files,
            Meta = model.Meta,
            LangId = model.LangId,
            ParentId = model.ParentId,
            ViewPath = model.ViewPath,
            WebsiteId = model.WebsiteId
        };

        var result = await _behlog.PublishAsync(command, cancellationToken);
        if (result.HasError)
        {
            model.WithValidationErrors(result.Errors);
            return model;
        }
        
        model.Succeed();
        return model;
    }

    public async Task<IntroBoxViewModel> LoadAsync(
        Guid websiteId, Guid langId, string name, CancellationToken cancellationToken = default)
    {
        var query = new QueryComponentByName(websiteId, langId, name);
        var component = await _behlog.PublishAsync(query, cancellationToken).ConfigureAwait(false);
        component.ThrowExceptionIfReferenceIsNull(nameof(component));

        var introBox = new IntroBoxViewModel
        {
            Id = component.Id,
            Name = component.Name,
            Title = component.Title,
            IsRtl = component.IsRtl,
            LangId = component.LangId,
            LangCode = component.LangCode,
            Description = component.Description,
            ParentId = component.ParentId,
            ViewPath = component.ViewPath,
            WebsiteId = component.WebsiteId,
            Attributes = (component.Attributes != null
                ? JsonConvert.DeserializeObject<IntroBoxAttributes>(component.Attributes)
                : new IntroBoxAttributes())!
        };

        return await Task.FromResult(introBox);
    }

    public async Task<IntroBoxViewModel> LoadAsync(
        Guid websiteId, string langCode, string name, CancellationToken cancellationToken = default)
    {
        var query = new QueryComponentByName(websiteId, langCode, name);
        var component = await _behlog.PublishAsync(query, cancellationToken).ConfigureAwait(false);
        component.ThrowExceptionIfReferenceIsNull(nameof(component));
        
        var introBox = new IntroBoxViewModel
        {
            Id = component.Id,
            Name = component.Name,
            Title = component.Title,
            IsRtl = component.IsRtl,
            LangId = component.LangId,
            LangCode = component.LangCode,
            Description = component.Description,
            ParentId = component.ParentId,
            ViewPath = component.ViewPath,
            WebsiteId = component.WebsiteId,
            Attributes = (component.Attributes != null
                ? JsonConvert.DeserializeObject<IntroBoxAttributes>(component.Attributes)
                : new IntroBoxAttributes())!
        };

        return await Task.FromResult(introBox);
    }
}