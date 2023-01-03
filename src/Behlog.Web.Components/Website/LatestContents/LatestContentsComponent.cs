using Behlog.Core;
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
    
}