namespace Behlog.Web.Models;

public class ContentCategoryViewModel
{
    public Guid Id { get; set; }
    public Guid WebsiteId { get; set; }
    public string Title { get; set; }
    public string? AltTitle { get; set; }
    public string Slug { get; set; }
    public Guid LangId { get; set; }
    public string LangCode { get; set; }
    public Guid? ParentId { get; set; }
    public string? Description { get; set; }
    public Guid? ContentTypeId { get; set; }
    public string ContentTypeName { get; set; }
    public string ContentTypeTitle { get; set; }
    public EntityStatusEnum Status { get; set; }
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
