using Behlog.Core.Models;
using Behlog.Web.Components.Base;

namespace Behlog.Web.Components;

public interface ILatestContentsComponent 
    : IBehlogWebComponent<UpdateLatestContentsViewModel, LatestContentsViewModel, LatestContentsAttributes>
{

    Task<IReadOnlyCollection<LatestContentsItemViewModel>> GetContentsAsync(
        Guid websiteId, string langCode, string contentTypeName, QueryOptions options);
}