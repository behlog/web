using Behlog.Web.Components;

namespace Behlog.Web.Controllers;

[Controller]
public class HomeController : Controller
{
    private readonly IImageSliderComponent _imageSliderComponent;
    private readonly BehlogWebsite _website;
    
    public HomeController(IImageSliderComponent imageSliderComponent, BehlogWebsite website)
    {
        _imageSliderComponent = imageSliderComponent ?? throw new ArgumentNullException(nameof(imageSliderComponent));
        _website = website ?? throw new ArgumentNullException(nameof(website));
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        // await _imageSliderComponent.InstallAsync(
        //     )

        var imageSlider = await _imageSliderComponent.LoadAsync(_website.Id, "fa", "homeslider");
        
        return View();
    }


    [HttpGet("image")]
    public async Task<IActionResult> Image()
    {
        await _imageSliderComponent.InstallAsync(
            _website.Id, _website.DefaultLangId, "HomeSlider", "Slider Home", null);

        var update = new UpdateImageSliderViewModel(_website.Id, _website.DefaultLangId, "HomeSlider")
        {
            Description = "A slider for HomePage",
            Name = "HomeSlider",
            Title = "Slider Home  ",
            IsRtl = true,
            Attributes = new List<ImageSliderItemViewModel>
            {
                new()
                {
                    Index = 0,
                    Title = "filan",
                    FileId = Guid.NewGuid(),
                    ImagePath = "~/uploads/filan/01.png",
                    AltTitle = "",
                    OrderNum = 1,
                    MoreInfoUrl = "http://filan.com",
                    Description = "asdad"
                },
                new()
                {
                    Index = 1,
                    Title = "fila1",
                    FileId = null,
                    ImagePath = "~/uploads/filan/02.png",
                    OrderNum = 2,
                    MoreInfoUrl = "http://filan2.com",
                    Description = "asdad"
                },
                new()
                {
                    Index = 2,
                    Title = "filan3",
                    FileId = Guid.NewGuid(),
                    ImagePath = "~/uploads/filan/03.png",
                    AltTitle = "",
                    OrderNum = 2,
                    MoreInfoUrl = "http://filan3.com",
                    Description = "asdad"
                },
                new()
                {
                    Index = 0,
                    Title = "filan4",
                    FileId = Guid.NewGuid(),
                    ImagePath = "~/uploads/filan/04.png",
                    OrderNum = 3,
                    MoreInfoUrl = "http://filan4.com",
                    Description = "asdad"
                },
            }
        };

        var result = await _imageSliderComponent.UpdateAsync(update, default);

        return Ok(result);
    }
}