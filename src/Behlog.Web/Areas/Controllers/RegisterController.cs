using Behlog.Core;
using Behlog.Web.Models.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Behlog.Web.Identity;

[Route("identity/register")]
public class RegisterController : Controller
{
    private readonly IBehlogManager _manager;

    public RegisterController(IBehlogManager manager)
    {
        _manager = manager ?? throw new ArgumentNullException(nameof(manager));
    }

    [HttpGet]
    public IActionResult Index()
    {
        var command = new RegisterUserCommand();
        
        return View("~/Views/default/Identity/Register.cshtml", command);
    }

    [HttpPost]
    public async Task<IActionResult> Index(RegisterUserCommand command)
    {
        if (!ModelState.IsValid)
        {
            command.AddError("Err");
            return View("~/Views/default/Identity/Register.cshtml", command);
        }
        
        var result = await _manager.PublishAsync(command).ConfigureAwait(false);


        result.Succeed();
        return View("~/Views/default/Identity/Register.cshtml", command);
    }
}