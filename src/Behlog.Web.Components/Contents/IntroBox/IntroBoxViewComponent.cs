using Microsoft.AspNetCore.Mvc;
using Behlog.Extensions;

namespace Behlog.Web.Components;

public class IntroBoxViewComponent : ViewComponent
{
    private readonly IIntroBoxComponent _component;


    public IntroBoxViewComponent(IntroBoxComponent component)
    {
        _component = component ?? throw new ArgumentNullException(nameof(component));
    }


    public async Task<IViewComponentResult> InvokeAsync(
        Guid websiteId, string langCode, string name)
    {
        var model = await _component.LoadAsync(websiteId, langCode, name);
        model.ThrowExceptionIfReferenceIsNull(nameof(model));
        
        if (model.ViewPath!.IsNotNullOrEmpty())
        {
            return View(model.ViewPath, model);
        }

        return View(model);
    }
}