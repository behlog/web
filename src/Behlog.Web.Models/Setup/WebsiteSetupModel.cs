namespace Behlog.Web.Models;


public class WebsiteSetupModel : BaseViewModel, IBehlogCommand<WebsiteSetupModel>
{
    [Required]
    [MaxLength(256)]
    public string Name { get; set; }
    
    [Required]
    [MaxLength(256)]
    public string Title { get; set; }
    
    [Required]
    public string Email { get; set; }
    
    [MaxLength(1000)]
    public string Keywords { get; set; }
    
    [MaxLength(2000)]
    public string Description { get; set; }
    
    [MaxLength(2000)]
    [Url(ErrorMessage = "The URL format is invalid.")]
    public string Url { get; set; }
    
    [MaxLength(1000)]
    public string CopyrightText { get; set; }
    
    
    public string LangCode { get; set; }
    
}