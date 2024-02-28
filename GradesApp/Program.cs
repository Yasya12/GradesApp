using Grades.Persistence;
using Grades.Application;
using Microsoft.AspNetCore.Identity;
using Grades.Persistence.Context;
using Grades.Domain.Entities.Utility;
using Microsoft.AspNetCore.Identity.UI.Services;
using Grades.Domain.Entities;
using Serilog;
using Serilog.Events;
using Serilog.Formatting.Compact;
using Serilog.Sinks.File;

var builder = WebApplication.CreateBuilder(args);

/*string rootPath = AppDomain.CurrentDomain.BaseDirectory;
string logFolderPath = Path.Combine(rootPath, "Logs");*/
string logFolderPath = Path.Combine(AppContext.BaseDirectory, "Logs");
string name = $"{DateTime.Now.Day}_{DateTime.Now.Month}_{DateTime.Now.Year}";
string logFileName = $"{name}.log";
string logFilePath = Path.Combine(logFolderPath, logFileName);

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
    .Enrich.FromLogContext()
    .WriteTo.File(logFilePath, rollingInterval: RollingInterval.Day)
    .CreateLogger();


builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();
builder.Services.AddRazorPages();

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddApplication();
builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddScoped<IEmailSender, EmailSender>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapRazorPages();
/*app.MapControllerRoute(
	name: "default",
	pattern: "{area=Customer}/{controller=Home}/{action=GetAll}/{id?}");*/

/*app.MapControllerRoute(
    name: "areaRoute",
    pattern: "{area:exists}/{controller=Home}/{action=GetAll}/{id?}");*/

/*app.MapControllerRoute(
    name: "default",
    pattern: "{area=Customer}/{controller=Home}/{action=Index}/{id?}");*/
/*app.Use(async (context, next) =>
{
    if (context.User.IsInRole(SD.Role_Faculty))
    {
        context.GetRouteData().Values["area"] = "Faculty";
    }

    else if (context.User.IsInRole(SD.Role_Admin))
    {
        context.GetRouteData().Values["area"] = "Admin";
    }

    await next();
});

app.UseRouting();*/
app.MapControllerRoute(
    name: "default",
    pattern: "{area=Customer}/{controller=Home}/{action=Index}/{id?}");


app.Run();
