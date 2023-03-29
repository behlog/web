using Behlog.Cms.Query;
using Behlog.Core;
using Behlog.Core.Models;
using Behlog.Web.Components.Base;

namespace Behlog.Web.Components;

public class LatestContentsComponent :
    BehlogWebComponent<UpdateLatestContentsViewModel, LatestContentsViewModel, LatestContentsAttributes>,
    ILatestContentsComponent
{
    private const string _componentType = "latestcontents";
    private const string _category = "content";
    private const string _author = "ImanN";
    private const string _authorEmail = "imun22@gmail.com";
    private const string _keywords = "content;news;section";

    public LatestContentsComponent(IBehlogMediator behlog) : base(behlog)
    {
    }
    
    public override string ComponentType => _componentType;
    public override string Category => _category;
    public override string Author => _author;
    public override string AuthorEmail => _authorEmail;
    public override string Keywords => _keywords;
    

    public async Task<IReadOnlyCollection<LatestContentsItemViewModel>> GetContentsAsync(
        Guid websiteId, string langCode, string contentTypeName, QueryOptions options) 
    {
        var query = new QueryPublishedContentsByContentTypeName(websiteId, langCode, contentTypeName, options);
        var result = await _behlog.PublishAsync(query).ConfigureAwait(false);

        return result.Results.Select(_ => new LatestContentsItemViewModel {
            AltTitle = _.AltTitle!,
            ContentId = _.Id,
            ContentTypeName = _.ContentTypeName!,
            ContentTypeTitle = _.ContentTypeTitle!,
            CoverPhoto = _.CoverPhoto!,
            IconName = _.IconName,
            LangId = _.LangId,
            Slug = _.Slug,
            Summary = _.Summary,
            Title = _.Title
        }).ToList();
    }
}