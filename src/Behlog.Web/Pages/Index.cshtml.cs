﻿using Behlog.Cms;
using Behlog.Cms.Commands;
using Behlog.Cms.Domain;
using Behlog.Core;
using Behlog.Web.Commands;
using Idyfa.Core.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Behlog.Web.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly IBehlogManager _manager;
    private readonly IIdyfaUserManager _userManager;

    public IndexModel(ILogger<IndexModel> logger, IBehlogManager manager, IIdyfaUserManager userManager)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _manager = manager ?? throw new ArgumentException(nameof(manager));
        _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
    }

    public async Task OnGetAsync()
    {
        var user = Idyfa.Core.User.RegisterUser(
            "imun", "dsdasd", "imun22@gmail.com", "9120939232", "iman", "nemati");
        
        var user_res = await _userManager.CreateAsync(user, "imUn_%rrR14^3}}");
        
        var command = new CreateWebsiteCommand(
            "Behlog", "Behlog - OpenSource Perisan Content Management System (CMS)",
            "Behlog", "Behlog, CMS", "http://behlog.ir", "sdsadas",
            PersianLanguage.Id, null, false, "hi@behlog.ir", "(c) 2022 Behlog");
        
        var website = await _manager.PublishAsync(command).ConfigureAwait(false);


        var cmd = new SampleCommand("FILAN");

        var result = await _manager.PublishAsync(cmd).ConfigureAwait(false);
        

        
    }
}