using Behlog.Core.Models;
using Behlog.Web.Components.Base;

namespace Behlog.Web.Components;


public class CommentInputViewModel 
    : WebComponentViewModel<CommentInputAttributeViewModel>
{

    public CommentInputViewModel()
    {
        Attributes = new CommentInputAttributeViewModel();
    }
}

public class CommentInputAttributeViewModel : BaseViewModel
{
    public Guid ContentId { get; set; }
    public string? Title { get; set; }
    public string Body { get; set; }
    public string? AuthorName { get; set; }
    public string? Email { get; set; }
    public string? WebUrl { get; set; }
}
