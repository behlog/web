using Behlog.Web.Components.Base;

namespace Behlog.Web.Components;

public class LatestContentsViewModel : WebComponentViewModel<LatestContentsAttributes>
{
}

public class LatestContentsAttributes
{
    public Guid? ContentTypeId { get; set; }
    public string? ContentTypeName { get; set; }
    public int Count { get; set; }
}

public class LatestContentsItemViewModel
{
    public Guid ContentId { get; set; }
    public string Title { get; set; }
    public string AltTitle { get; set; }
    public string Slug { get; set; }
    public string Summary { get; set; }
    public string CoverPhoto { get; set; }
    public string? IconName { get; set; }
    public string ContentTypeName { get; set; }
    public string Url { get; set; }
}

public class UpdateLatestContentsViewModel : UpdateWebComponentViewModel<LatestContentsAttributes>
{
    public UpdateLatestContentsViewModel(Guid websiteId, Guid langId, string name) 
        : base(websiteId, langId, name)
    {
    }
}