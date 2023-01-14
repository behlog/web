namespace Behlog.Web.Models;

public class ContentDetailsViewModel
{
    public ContentDetailsViewModel() { 
        Categories = new List<ContentCategoryViewModel>();
        RelatedContents = new List<ContentViewModel>();
    }

    public ContentViewModel Content { get; set; }
    public ICollection<ContentCategoryViewModel> Categories { get; set; }
    public ICollection<ContentViewModel> RelatedContents { get; set; }
}
