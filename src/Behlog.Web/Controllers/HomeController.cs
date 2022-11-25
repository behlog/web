using Behlog.Cms.EntityFrameworkCore;

namespace Behlog.Web.Controllers;

[Controller]
public class HomeController : Controller
{
    private readonly IBehlogEntityFrameworkDbContext _dbContext;

    public HomeController(IBehlogEntityFrameworkDbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

        var exist = _dbContext.CheckDatabaseExist();

        var filan = "kos";
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }
}