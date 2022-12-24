using Behlog.Cms.Models;
using DNTPersianUtils.Core;

namespace Behlog.Web.Models;

public class ContentViewModel : ContentResult
{
    public ContentViewModel() { }

    public ContentViewModel(ContentResult result) {
        Id = result.Id;
        Title = result.Title;
        Slug = result.Slug;
        ContentTypeId = result.ContentTypeId;
        ContentTypeSlug = result.ContentTypeSlug;
        ContentTypeTitle = result.ContentTypeTitle;
        LangId = result.LangId;
        LangTitle = result.LangTitle;
        LangCode = result.LangCode;
        Body = result.Body;
        BodyType = result.BodyType;
        CoverPhoto = result.CoverPhoto;
        AuthorUserId = result.AuthorUserId;
        AuthorUserDisplayName = result.AuthorUserDisplayName;
        AuthorUserName = result.AuthorUserName;
        Summary = result.Summary;
        Status = result.Status;
        LastStatusChangedDate = result.LastStatusChangedDate;
        PublishDate = result.PublishDate;
        AltTitle = result.AltTitle;
        OrderNum = result.OrderNum;
        IconName = result.IconName;
        ViewPath = result.ViewPath;
        CreatedDate = result.CreatedDate;
        LastUpdated = result.LastUpdated;
        CreatedDate = result.CreatedDate;
        LastUpdated = result.LastUpdated;
        CreatedByUserId = result.CreatedByUserId;
        LastUpdatedByUserId = result.LastUpdatedByUserId;
        CreatedByIp = result.CreatedByIp;
        LastUpdatedByIp = result.LastUpdatedByIp;
        LikesCount = result.LikesCount;
        Categories = result.Categories;
        Meta = result.Meta;
        Files = result.Files;
        Tags = result.Tags;
    }

    public string? PublishDateDisplay
        => PublishDate?.ToLocalTime().ToPersianDateTextify();

    public string CreateDateDisplay
        => CreatedDate.ToLocalTime().ToPersianDateTextify();

    public string? LastUpdatedDisplay
        => LastUpdated?.ToLocalTime().ToPersianDateTextify();


}