using Behlog.Core;
using Behlog.Web.Application;
using Behlog.Web.Models.Identity;
using Microsoft.AspNetCore.Mvc;

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
        var command = new RegisterUserCommand();
        return _View(command);
    }

    [HttpPost]
    public async Task<IActionResult> Index(RegisterUserCommand command)
    {
        if (!ModelState.IsValid)
        {
            command.AddError("Err");
            return _View(command);
        }
        
        var result = await _mediator.PublishAsync(command).ConfigureAwait(false);

        return View($"~/Views/{_website.Theme}/{BehlogWebsiteAreaNames.Identity}/Register.cshtml", command);
    }


    #region Return Views

    private ViewResult _View(RegisterUserCommand command)
    {
        return View($"~/Views/{_website.Theme}/{BehlogWebsiteAreaNames.Identity}/Register.cshtml", command);
    }
    
    
    #endregion
}