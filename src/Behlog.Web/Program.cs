using Behlog.Core.Models;
using Idyfa.Core;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddOptions();
var basePath = Directory.GetCurrentDirectory();
Console.WriteLine($"Using '{basePath}' as the root.");
var configuration = new ConfigurationBuilder()
    .SetBasePath(basePath)
    .AddJsonFile("appsettings.json", false, reloadOnChange: true)
    .Build();

builder.Services.AddSingleton<IConfigurationRoot>(provider => configuration);
builder.Services.Configure<IdyfaConfigRoot>(options => configuration.Bind(options));

builder.Services.AddIdyfaCore();
builder.Services.AddIdyfaEntityFrameworkCore();
builder.Services.AddIdyfaSQLiteDatabase(new IdyfaDbConfigItem
{
    Name = "BehlogDb",
    Timeout = 3000,
    ConnectionString = "Data Source=Behlog.db;"
});
builder.Services.AddBehlogCore();
builder.Services.AddBehlogCMS();
builder.Services.AddBehlogCmsEntityFrameworkCoreSQLite(
    new BehlogDbConfig
    {
        DbName = "BehlogDb",
        Timeout = 3000,
        ConnectionString = "Data Source=Behlog.db;"
    });
builder.Services.AddBehlogCmsEntityFrameworkCoreReadStores();
builder.Services.AddBehlogCmsEntityFrameworkCoreWriteStores();


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

app.UseAuthorization();

app.MapRazorPages();

app.Run();