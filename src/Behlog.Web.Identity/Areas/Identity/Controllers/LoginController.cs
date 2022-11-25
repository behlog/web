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
        var command = new LoginUserCommand();
        return View($"~/Views/{_website.Theme}/{WebsiteAreaNames.Identity}/Login.cshtml", command);
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Index(LoginUserCommand command)
    {
        if (!ModelState.IsValid)
        {
            command.AddError("Model is not valid.");
            return View($"~/Views/{_website.Theme}/{WebsiteAreaNames.Identity}/Login.cshtml", command);
        }

        var result = await _mediator.PublishAsync(command).ConfigureAwait(false);
        
        return View($"~/Views/{_website.Theme}/{WebsiteAreaNames.Identity}/Login.cshtml", command);
    }
}