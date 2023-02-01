using Behlog.Web.Services.Contracts;

namespace Behlog.Web.Identity;


[Area(WebsiteAreaNames.Identity)]
[Route("[area]/login2")]
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
        var model = new UserLoginModel();
        return View(model);
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Index(UserLoginModel model)
    {
        if (!ModelState.IsValid)
        {
            model.AddError("Model is not valid.");
            return View(model);
        }
        
        var result = await _userIdentityService.LoginAsync(model);
        if (result.HasError)
        {
            model.AddError(result.Errors.ToString()!);
            return View(model);
        }
        
        model.Succeed();
        return View(model);
    }
}