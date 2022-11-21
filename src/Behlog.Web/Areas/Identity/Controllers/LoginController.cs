using Behlog.Core;
using Behlog.Web.Application;
using Behlog.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Behlog.Web.Identity;

[Area(BehlogWebsiteAreaNames.Identity)]
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
        var model = new LoginUserCommand();
        return View(model);
    }
    
    
}