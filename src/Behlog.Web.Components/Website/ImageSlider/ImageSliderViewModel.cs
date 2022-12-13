namespace Behlog.Web.Components;

public class ImageSliderViewModel
{
    public ImageSliderViewModel()
    {
        Images = new List<ImageSliderItemViewModel>();    
    }
    
    public ICollection<ImageSliderItemViewModel> Images { get; set; }
}


public class ImageSliderItemViewModel
{
    public int Index { get; set; }
    public string Title { get; set; }
    public string ImagePath { get; set; }
    public string? AltImagePath { get; set; }
    public Guid? FileId { get; set; }
    public string? Description { get; set; }
    public string? AltTitle { get; set; }
    public string? MoreInfoUrl { get; set; }
}