using Behlog.Core;
using Behlog.Cms.Query;
using Behlog.Extensions;
using Behlog.Cms.Commands;
using Newtonsoft.Json;

namespace Behlog.Web.Components.Base;

/// <inheritdoc />
public class BehlogWebComponent<TUpdateModel, TViewModel, TAttributeType> 
    : IBehlogWebComponent<TUpdateModel, TViewModel, TAttributeType>
        where TUpdateModel : UpdateWebComponentViewModel<TAttributeType>
        where TViewModel : WebComponentViewModel<TAttributeType>, new()
        where TAttributeType : class
{
    protected readonly IBehlogMediator _behlog;
    
    public BehlogWebComponent(IBehlogMediator behlog)
    {
        _behlog = behlog ?? throw new ArgumentNullException(nameof(behlog));
    }
    
    public virtual string ComponentType { get; }
    public virtual string Category { get; }
    public virtual string Author { get; }
    public virtual string AuthorEmail { get; }
    public virtual string Keywords { get; }

    
    /// <inheritdoc />
    public virtual async Task InstallAsync(
        Guid websiteId, Guid langId, string name, string title, Guid? parentId, 
        string? description = null, bool isRtl = false, string? viewPath = null)
    {
        var command = new UpsertComponentCommand
        {
            WebsiteId = websiteId,
            Author = Author,
            Category = Category,
            Name = name,
            Title = title,
            ComponentType = ComponentType,
            AuthorEmail = AuthorEmail,
            Keywords = Keywords,
            Description = description,
            IsRtl = isRtl,
            LangId = langId,
            ParentId = parentId,
            ViewPath = viewPath,
        };

        var component = await _behlog.PublishAsync(command).ConfigureAwait(false);
        if (component.HasError)
        {
            Console.WriteLine($"Component '{component.Value.Name}' install error with message : {component.Errors.ToString()}");
            return;    
        }
        
        Console.WriteLine($"Component '{component.Value.Name}' created successfully.");
    }

    
    /// <inheritdoc />
    public virtual async Task<TUpdateModel> UpdateAsync(
        TUpdateModel model, CancellationToken cancellationToken = default)
    {
        model.ThrowExceptionIfArgumentIsNull(nameof(model));

        var command = new UpsertComponentCommand
        {
            Attributes = model.Attributes != null 
                ? JsonConvert.SerializeObject(model.Attributes, Formatting.Indented)
                : null,
            Author = this.Author,
            Category = Category,
            Description = model.Description,
            Keywords = Keywords,
            Name = model.Name,
            Title = model.Title,
            AuthorEmail = AuthorEmail,
            IsRtl = model.IsRtl,
            ComponentType = ComponentType,
            LangId = model.LangId,
            ParentId = model.ParentId,
            ViewPath = model.ViewPath,
            WebsiteId = model.WebsiteId,
            Files = model.Files,
            Meta = model.Meta
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

    /// <inheritdoc />
    public async Task<TViewModel> LoadAsync(Guid websiteId, Guid langId, string name, CancellationToken cancellationToken = default)
    {
        var query = new QueryComponentByName(websiteId, langId, name);
        var component = await _behlog.PublishAsync(query, cancellationToken).ConfigureAwait(false);
        component.ThrowExceptionIfReferenceIsNull(nameof(component));
        
        var model = new TViewModel
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
                ? JsonConvert.DeserializeObject<TAttributeType>(component.Attributes)
                : default)!
        };

        return await Task.FromResult(model);
    }

    /// <inheritdoc /> 
    public async Task<TViewModel> LoadAsync(
        Guid websiteId, string langCode, string name, CancellationToken cancellationToken = default)
    {
        var query = new QueryComponentByName(websiteId, langCode, name);
        var component = await _behlog.PublishAsync(query, cancellationToken).ConfigureAwait(false);
        component.ThrowExceptionIfReferenceIsNull(nameof(component));
        
        var model = new TViewModel
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
                ? JsonConvert.DeserializeObject<TAttributeType>(component.Attributes)
                : default)!
        };

        return await Task.FromResult(model);
    }
}