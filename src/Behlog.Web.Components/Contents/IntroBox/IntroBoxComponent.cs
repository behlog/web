using Behlog.Core;
using Behlog.Web.Components.Base;

namespace Behlog.Web.Components;

public class IntroBoxComponent :
    BehlogWebComponent<UpdateIntroBoxViewModel, IntroBoxViewModel, IntroBoxAttributes>,
    IIntroBoxComponent
{
    private const string _componentType = "introbox";
    private const string _category = "boxes";
    private const string _author = "ImanN";
    private const string _authorEmail = "imun22@gmail.com";
    private const string _keywords = "intro; info; summary";

    public override string ComponentType => _componentType;
    public override string Category => _category;
    public override string Author => _author;
    public override string AuthorEmail => _authorEmail;
    public override string Keywords => _keywords;

    public IntroBoxComponent(IBehlogMediator behlog) : base(behlog)
    {
    }
    
}