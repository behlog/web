namespace Behlog.Web.Identity;

[Area(WebsiteAreaNames.Identity)]
[Route("[area]")]
public class IdentityController : Controller
{
    private readonly IIdyfaAuthManager _auth;


    public IdentityController(IIdyfaAuthManager auth)
    {
        _auth = auth ?? throw new ArgumentNullException(nameof(auth));
    }

    [HttpGet("logout")]
    public async Task<IActionResult> Logout()
    {
        await _auth.SignOutAsync(User);
        return RedirectToAction("Index", "Login");
    }
}