using EPiServer.ContentApi.Core.Serialization;
using EPiServer.ContentApi.Core.Serialization.Internal;
using EPiServer.ContentApi.Core.Serialization.Models;
using EPiServer.Framework.Web;
using EPiServer.Shell.Modules;
using EPiServer.Web.Routing;
using InertiaCore.Extensions;
using OptimizelyCmsInertiaDemo.Services;

var builder = WebApplication.CreateBuilder(args);

// Optimizely registers some framework services that are resolved lazily at runtime.
// ASP.NET Core's build-time validation can fail early in Development even though runtime resolution works.
builder.Host.UseDefaultServiceProvider(options =>
{
    options.ValidateOnBuild = false;
    options.ValidateScopes = false;
});

builder.Services
    .AddCms()
    .AddContentDeliveryApi(options =>
    {
        options.SiteDefinitionApiEnabled = true;
    });

builder.Services.AddControllersWithViews();
builder.Services.AddInertia();

// Required by EPiServer.Cms.Shell.VppInitializer when extension endpoints are mapped.
builder.Services.AddSingleton(new ProtectedModuleOptions());

builder.Services.AddScoped<IInertiaContentProjector, OptimizelyCdaInertiaContentProjector>();

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.UseInertia();

app.MapControllers();
app.MapContent();

app.Run();
