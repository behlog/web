using Behlog.Web.Components.Base;

namespace Behlog.Web.Components;

public class ImageSliderViewModel 
    : WebComponentViewModel<ICollection<ImageSliderItemViewModel>>
{
    public ImageSliderViewModel()
    {
        Attributes = new List<ImageSliderItemViewModel>();    
    }
    
}


public class ImageSliderItemViewModel
{
    public long Id { get; set; }
    public int Index { get; set; }
    public string Title { get; set; }
    public string ImagePath { get; set; }
    public string? AltImagePath { get; set; }
    public Guid? FileId { get; set; }
    public Guid? AlternateFileId { get; set; }
    public string? Description { get; set; }
    public string? AltTitle { get; set; }
    public string? MoreInfoUrl { get; set; }
    public int OrderNum { get; set; }
}


public class UpdateImageSliderViewModel : UpdateWebComponentViewModel<ICollection<ImageSliderItemViewModel>>
{
    public UpdateImageSliderViewModel(Guid websiteId, Guid langId, string name) 
        : base(websiteId, langId, name)
    {
        Attributes = new List<ImageSliderItemViewModel>();
    }
    
}