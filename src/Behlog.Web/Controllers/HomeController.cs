using Behlog.Web.Components;

namespace Behlog.Web.Controllers;

[Controller]
public class HomeController : Controller
{
    private readonly IImageSliderComponent _imageSliderComponent;
    
    public HomeController(IImageSliderComponent imageSliderComponent)
    {
        _imageSliderComponent = imageSliderComponent ?? throw new ArgumentNullException(nameof(imageSliderComponent));
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        // await _imageSliderComponent.InstallAsync(
        //     )
        
        return View();
    }
}