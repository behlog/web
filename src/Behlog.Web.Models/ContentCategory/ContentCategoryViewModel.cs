namespace Behlog.Web.Models;

public class ContentCategoryViewModel : ContentCategoryResult
{

    public ContentCategoryViewModel() { }

    public ContentCategoryViewModel(ContentCategoryResult result) {
        if (result == null) {
            throw new ArgumentNullException(nameof(result));
        }

        Id = result.Id;
        Title = result.Title;
        AltTitle = result.AltTitle;
        Slug = result.Slug;
        LangId = result.LangId;
        LangCode = result.LangCode;
        ParentId = result.ParentId;
        Description = result.Description;
        ContentTypeId = result.ContentTypeId;
        ContentTypeSystemName = result.ContentTypeSystemName;
        ContentTypeTitle = result.ContentTypeTitle;
        ContentTypeSlug = result.ContentTypeSlug;
        Status = result.Status;
        WebsiteId = result.WebsiteId;
        WebsiteName = result.WebsiteName;
        WebsiteTitle = result.WebsiteTitle;
        LangTitle = result.LangTitle;
    }

    public DateTime CreatedDate { get; set; }
    public string CreatedDateDisplay => CreatedDate.ToLocalTime().ToPersianDateTextify();
    public DateTime? LastUpdated { get; set; }
    public string? LastUpdatedDisplay => LastUpdated?.ToLocalTime().ToPersianDateTextify();
    public string? CreatedByUserId { get; set; }
    public string? CreatedByUserName { get; set; }
    public string? CreatedByUserDisplayName { get; set; }
    public string? LastUpdatedByUserId { get; set; }
    public string? LastUpdatedByUserName { get; set; }
    public string? LastUpdatedByUserDisplayName { get; set; }
    public string? CreatedByIp { get; set; }
    public string? LastUpdatedByIp { get; set; }
    public DateTime? LastStatusChangedOn { get; set; }
    public string? LastStatusChangedOnDisplay => LastStatusChangedOn?.ToLocalTime().ToPersianDateTextify();
}
