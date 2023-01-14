using Microsoft.AspNetCore.Mvc;
using Behlog.Cms;
using Behlog.Extensions;

namespace Behlog.Web.Components;

public class ImageSliderViewComponent : ViewComponent
{
    private readonly IImageSliderComponent _component;

    public ImageSliderViewComponent(IImageSliderComponent component)
    {
        _component = component;
    }

    public async Task<IViewComponentResult> InvokeAsync(
        Guid websiteId, string langCode, string name)
    {
        var model = await _component.LoadAsync(
            websiteId, BehlogSupportedLanguages.GetIdByCode(langCode), name);
        model.ThrowExceptionIfReferenceIsNull(nameof(model));

        if (model.ViewPath!.IsNotNullOrEmpty())
        {
            return View(model.ViewPath, model);
        }

        return View(model);
    }
}