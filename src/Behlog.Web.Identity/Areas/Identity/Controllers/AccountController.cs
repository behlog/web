using Idyfa.Core.Contracts;

namespace Behlog.Web.Identity;

[Area(WebsiteAreaNames.Identity)]
[Route("[area]/account")]
[Authorize]
public class AccountController : Controller
{
    private readonly IBehlogMediator _mediator;
    private readonly BehlogWebsite _website;
    private readonly IIdyfaUserContext _userContext;


    public AccountController(
        IBehlogMediator mediator, BehlogWebsite website, IIdyfaUserContext userContext)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        _website = website ?? throw new ArgumentNullException(nameof(website));
        _userContext = userContext ?? throw new ArgumentNullException(nameof(userContext));
    }

    [HttpGet]
    public IActionResult Index()
    {
        var model = new AccountIndexModel
        {
            Id = _userContext.UserId,
            DisplayName = _userContext.DisplayName,
            UserName = _userContext.UserName
        };
        return _View(model);
    }


    #region Return Views

    private ViewResult _View(AccountIndexModel model)
    {
        return View(
            $"~/Views/{_website.TemplateName}/{WebsiteAreaNames.Identity}/Account/Index.cshtml", 
            model);
    }

    #endregion
}