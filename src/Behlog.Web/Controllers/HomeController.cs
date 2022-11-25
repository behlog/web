using Behlog.Cms.EntityFrameworkCore;

namespace Behlog.Web.Controllers;

[Controller]
public class HomeController : Controller
{
    public HomeController()
    {
        
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }
}