using Behlog.Web.Components.Base;

namespace Behlog.Web.Components;

public class IntroBoxViewModel : WebComponentViewModel<IntroBoxAttributes>
{

}

public class IntroBoxAttributes
{
    public Guid? ContentId { get; set; }
    public string Title { get; set; }
    public string? AltTitle { get; set; }
    public string? LangCode { get; set; }
    public string? IconName { get; set; }
    public string? ImagePath { get; set; }
    public Guid? ImageFileId { get; set; }
    public string? AltImagePath { get; set; }
    public string? AltImageFileId { get; set; }
    public string Body { get; set; }
    public int? BodyMaxLen { get; set; }
    public string? Url { get; set; }
    public string? AltUrl { get; set; }
}


public class UpdateIntroBoxViewModel : UpdateWebComponentViewModel
{
    public UpdateIntroBoxViewModel(Guid websiteId, Guid langId, string name) 
        : base(websiteId, langId, name)
    {
    }
    
    public Guid? ContentId { get; set; }
    public string Title { get; set; }
    public string? AltTitle { get; set; }
    public string? LangCode { get; set; }
    public string? IconName { get; set; }
    public string? ImagePath { get; set; }
    public Guid? ImageFileId { get; set; }
    public string? AltImagePath { get; set; }
    public string? AltImageFileId { get; set; }
    public string Body { get; set; }
    public int? BodyMaxLen { get; set; }
    public string? Url { get; set; }

}
