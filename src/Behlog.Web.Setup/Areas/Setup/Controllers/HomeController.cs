using Behlog.Core;
using Behlog.Web.Core;
using Behlog.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Behlog.Web.Setup;


[Controller]
[Area(WebsiteAreaNames.Setup)]
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
        await _mediator.PublishAsync(model).ConfigureAwait(false);
        
        return View();
    }
}