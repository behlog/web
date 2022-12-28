using Behlog.Web.Services.Contracts;

namespace Behlog.Web.Identity;


[Area(WebsiteAreaNames.Identity)]
[Route("[area]/login")]
public class LoginController : Controller
{
    private readonly IUserIdentityService _userIdentityService;
    private readonly BehlogWebsite _website;

    public LoginController(IUserIdentityService userIdentityService, BehlogWebsite website)
    {
        _userIdentityService = userIdentityService ?? throw new ArgumentNullException(nameof(userIdentityService));
        _website = website ?? throw new ArgumentNullException(nameof(website));
    }

    [HttpGet]
    public IActionResult Index()
    {
        var model = new LoginUserModel();
        return View($"~/Views/{_website.TemplateName}/{WebsiteAreaNames.Identity}/Login.cshtml", model);
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Index(LoginUserModel model)
    {
        if (!ModelState.IsValid)
        {
            model.AddError("Model is not valid.");
            return View($"~/Views/{_website.TemplateName}/{WebsiteAreaNames.Identity}/Login.cshtml", model);
        }



        var result = await _userIdentityService.LoginAsync(model);
        if (result.HasError)
        {
            model.AddError(result.Errors.ToString()!);
            return View($"~/Views/{_website.TemplateName}/{WebsiteAreaNames.Identity}/Login.cshtml", model);
        }
        
        model.Succeed();
        return View($"~/Views/{_website.TemplateName}/{WebsiteAreaNames.Identity}/Login.cshtml", model);
    }
}