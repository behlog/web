using Behlog.Core;
using Behlog.Extensions;
using Behlog.Web.Core;
using Behlog.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Behlog.Web.Setup;


[Controller]
[Area(WebsiteAreaNames.Setup)]
[Route("[area]")]
public class HomeController : Controller
{
    private readonly IBehlogMediator _mediator;

    public HomeController(IBehlogMediator mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }
    
    
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var model = new WebsiteSetupModel();
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Index(WebsiteSetupModel model)
    {
        model.ThrowExceptionIfArgumentIsNull(nameof(model));

        if (!ModelState.IsValid)
        {
            model.AddError("The Model is not valid");
            return View(model);
        }

        await _mediator.PublishAsync(model).ConfigureAwait(false);

        return View(model);
    }
}