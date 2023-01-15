namespace Behlog.Web.Models;

public class CreateCommentViewModel : BaseViewModel
{
    public Guid ContentId { get; set; }
    
    [MaxLength(500)]
    public string? Title { get; set; }
    
    [MaxLength(4000)]
    public string Body { get; set; }
    
    [MaxLength(256)]
    public string? AuthorName { get; set; }
    
    [MaxLength(1000)]
    public string? Email { get; set; }
    
    [MaxLength(2000)]
    public string? WebUrl { get; set; }
}