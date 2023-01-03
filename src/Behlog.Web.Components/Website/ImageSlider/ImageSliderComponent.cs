using Behlog.Core;
using Behlog.Web.Components.Base;

namespace Behlog.Web.Components;

public class ImageSliderComponent 
    : BehlogWebComponent<UpdateImageSliderViewModel, ImageSliderViewModel, ICollection<ImageSliderItemViewModel>>,
        IImageSliderComponent

{
    private const string _componentType = "imageslider";
    private const string _category = "slider";
    private const string _author = "ImanN";
    private const string _authorEmail = "imun22@gmail.com";
    private const string _keywords = "slider;images;gallery";

    public ImageSliderComponent(IBehlogMediator behlog) : base(behlog)
    {
    }

    public override string ComponentType => _componentType;
    public override string Category => _category;
    public override string Author => _author;
    public override string AuthorEmail => _authorEmail;
    public override string Keywords => _keywords;
    
}