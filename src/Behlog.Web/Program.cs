using System.Reflection;
using Behlog.Cms.Domain;
using Behlog.Core.Models;
using Idyfa.Core;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddOptions();
IConfiguration config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .AddEnvironmentVariables()
    .Build();

var idyfaOptions = config.Get<IdyfaConfigRoot>().Idyfa;
var behlogOptions = config.Get<BehlogOptions>();

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(20);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
builder.Services.AddRouting(options => options.LowercaseUrls = true);
var sqliteCfg = idyfaOptions.IdyfaDbConfig.Databases.FirstOrDefault(_ =>
    _.Name.Equals("SQLite", StringComparison.InvariantCultureIgnoreCase));
builder.Services.AddIdyfaSQLiteDatabase(sqliteCfg);
builder.Services.AddIdyfaEntityFrameworkCore();
builder.Services.AddIdyfaCore(idyfaOptions);

var assemblies = AppDomain.CurrentDomain.GetAssemblies();

// builder.Services.AddBehlogManager(new List<Assembly>
// {
//     Assembly.GetAssembly(typeof(Website))!
// });
// builder.Services.AddBehlogMiddleware(new List<Assembly>
// {
//     Assembly.GetAssembly(typeof(Website))!
// });

builder.Services.AddBehlogCore();
// builder.Services.AddBehlogManager();
// builder.Services.AddBehlogMiddleware();
builder.Services.AddBehlogCms();
builder.Services.AddBehlogCmsEntityFrameworkCoreSQLite(behlogOptions.DbConfig);
builder.Services.AddBehlogCmsEntityFrameworkCoreReadStores();
builder.Services.AddBehlogCmsEntityFrameworkCoreWriteStores();

builder.Services.AddAuthorization().AddAuthentication();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
app.UseEndpoints(endpoints => {
    endpoints.MapControllers();
});

app.Run();