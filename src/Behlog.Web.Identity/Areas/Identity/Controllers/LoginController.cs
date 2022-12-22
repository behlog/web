namespace Behlog.Web.Identity;


[Area(WebsiteAreaNames.Identity)]
[Route("[area]/login")]
public class LoginController : Controller
{
    private readonly IBehlogMediator _mediator;
    private readonly BehlogWebsite _website;

    public LoginController(IBehlogMediator mediator, BehlogWebsite website)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
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

        var command = new LoginUserCommand(
            model.UserName, model.Password, model.RememberMe);
        
        var result = await _mediator.PublishAsync(command).ConfigureAwait(false);
        if (result.HasError)
        {
            
        }
        
        return View($"~/Views/{_website.TemplateName}/{WebsiteAreaNames.Identity}/Login.cshtml", model);
    }
}