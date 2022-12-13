using Behlog.Cms.Contracts;
using Behlog.Cms.Seed;
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
    private readonly ICmsSetup _setup;

    public HomeController(ICmsSetup setup)
    {
        _setup = setup ?? throw new ArgumentNullException(nameof(setup));
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

        await _setup.SetupAsync(new WebsiteSeedData
        {
            Id = Guid.NewGuid().ToString(),
            Email = model.Email,
            Name = model.Name,
            Description = model.Description,
            Keywords = model.Keywords,
            Title = model.Title,
            Url = model.Url,
            CopyrightText = model.CopyrightText,
            LangCode = model.LangCode
        }, ensureDbCreated: true);

        model.Succeed();
        return View(model);
    }
}