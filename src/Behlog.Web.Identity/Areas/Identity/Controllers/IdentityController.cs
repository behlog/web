using Behlog.Extensions;

namespace Behlog.Web.Identity;
using Behlog.Web.Services.Contracts;

[Area(WebsiteAreaNames.Identity)]
[Route("[area]")]
public class IdentityController : Controller
{
    private readonly IIdyfaAuthManager _auth;
    private readonly IUserIdentityService _userIdentityService;
    
    public IdentityController(
        IIdyfaAuthManager auth, IUserIdentityService userIdentityService)
    {
        _auth = auth ?? throw new ArgumentNullException(nameof(auth));
        _userIdentityService = userIdentityService ?? throw new ArgumentNullException(nameof(userIdentityService));
    }

    [HttpGet("login")]
    public IActionResult Login(string? returnUrl = null)
    {
        var model = new UserLoginModel
        {
            ReturnUrl = returnUrl
        };
        
        return View(model);
    }
    
    [HttpPost("login"), ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(UserLoginModel model)
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

        if (model.ReturnUrl.IsNotNullOrEmpty())
        {
            return Redirect(model.ReturnUrl);
        }

        return RedirectToAction("Index", "Home", new { area = WebsiteAreaNames.Identity });
    }
    
    
    [HttpGet("logout")]
    public async Task<IActionResult> Logout()
    {
        await _auth.SignOutAsync(User);
        return RedirectToAction("Index", "Login");
    }
}