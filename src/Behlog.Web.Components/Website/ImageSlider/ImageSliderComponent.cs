using Behlog.Core;
using Behlog.Cms.Query;
using Behlog.Cms.Commands;
using Behlog.Extensions;
using Newtonsoft.Json;

namespace Behlog.Web.Components;

public class ImageSliderComponent : IImageSliderComponent
{
    private const string _componentType = "imageslider";
    private const string _category = "slider";
    private const string _author = "Iman N";
    private const string _authorEmail = "imun22@gmail.com";
    private const string _keywords = "slider;images;gallery";

    private readonly IBehlogMediator _behlog;


    public ImageSliderComponent(IBehlogMediator behlog)
    {
        _behlog = behlog ?? throw new ArgumentNullException(nameof(behlog));
    }

    public string ComponentType => _componentType;
    public string Category => _category;
    public string Author => _author;
    public string AuthorEmail => _authorEmail;
    public string Keywords => _keywords;

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


    public async Task<ImageSliderViewModel> LoadAsync(
        Guid websiteId, Guid langId, string name, CancellationToken cancellationToken = default)
    {
        var query = new QueryComponentByName(websiteId, langId, name);
        var component = await _behlog.PublishAsync(query, cancellationToken).ConfigureAwait(false);
        component.ThrowExceptionIfReferenceIsNull(nameof(component));

        var imageSlider = new ImageSliderViewModel
        {
            Name = component.Name,
            Title = component.Title,
            IsRtl = component.IsRtl,
            LangId = component.LangId,
            LangCode = component.LangCode,
            Images = (component.Attributes != null
                ? JsonConvert.DeserializeObject<ICollection<ImageSliderItemViewModel>>(component.Attributes)
                : new List<ImageSliderItemViewModel>())!
        };

        return await Task.FromResult(imageSlider);
    }


    public async Task<UpdateImageSliderViewModel> UpdateAsync(UpdateImageSliderViewModel model, CancellationToken cancellationToken = default)
    {
        model.ThrowExceptionIfArgumentIsNull(nameof(model));

        var command = new UpsertComponentCommand
        {
            Attributes = model.Images != null && model.Images.Any()
                ? JsonConvert.SerializeObject(model.Images, Formatting.Indented)
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
}