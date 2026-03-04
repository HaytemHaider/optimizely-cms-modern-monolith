using EPiServer.ContentApi.Core.Serialization;
using EPiServer.ContentApi.Core.Serialization.Internal;
using EPiServer.ContentApi.Core.Serialization.Models;
using EPiServer.Framework.Web;
using EPiServer.Web.Routing;
using InertiaCore.Extensions;
using OptimizelyCmsInertiaDemo.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddCms()
    .AddContentDeliveryApi(options =>
    {
        options.SiteDefinitionApiEnabled = true;
    });

builder.Services.AddControllersWithViews();
builder.Services.AddInertia();

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
