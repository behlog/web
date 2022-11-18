using Behlog.Cms;
using Behlog.Cms.Commands;
using Behlog.Cms.Domain;
using Behlog.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Behlog.Web.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly IBehlogManager _manager;

    public IndexModel(ILogger<IndexModel> logger, IBehlogManager manager)
    {
        _logger = logger;
        _manager = manager ?? throw new ArgumentException(nameof(manager));
    }

    public async Task OnGetAsync()
    {
        var command = new CreateWebsiteCommand(
            "Behlog", "Behlog - OpenSource Perisan Content Management System (CMS)",
            "Behlog", "Behlog, CMS", "http://behlog.ir", "sdsadas",
            PersianLanguage.Id, null, false, "hi@behlog.ir", "(c) 2022 Behlog");

        var website = await _manager.PublishAsync(command).ConfigureAwait(false);
        
    }
}