namespace Behlog.Web.Identity;

[Area("Identity")]
[Route("[area]/register")]
public class RegisterController : Controller
{
    private readonly IBehlogMediator _mediator;
    private readonly BehlogWebsite _website;

    public RegisterController(IBehlogMediator mediator, BehlogWebsite website)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        _website = website ?? throw new ArgumentNullException(nameof(website));
    }

    [HttpGet]
    public IActionResult Index()
    {
        var model = new RegisterUserModel();
        return _View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Index(RegisterUserModel model)
    {
        if (!ModelState.IsValid)
        {
            model.AddError("Err");
            return _View(model);
        }

        var command = new RegisterUserCommand(model.UserName)
        {
            Email = model.Email,
            Password = model.Password,
            DisplayName = model.DisplayName,
            FirstName = model.FirstName,
            LastName = model.LastName,
            PhoneNumber = model.PhoneNumber,
            UserName = model.UserName
        };

        var result = await _mediator.PublishAsync(command).ConfigureAwait(false);
        if (result.HasError)
        {
            
        }

        return View($"~/Views/{_website.TemplateName}/{WebsiteAreaNames.Identity}/Register.cshtml", model);
    }


    #region Return Views

    private ViewResult _View(RegisterUserModel model)
    {
        return View($"~/Views/{_website.TemplateName}/{WebsiteAreaNames.Identity}/Register.cshtml", model);
    }

    #endregion
}