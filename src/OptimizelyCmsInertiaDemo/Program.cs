using EPiServer.ContentApi.Core.Serialization;
using EPiServer.ContentApi.Core.Serialization.Internal;
using EPiServer.ContentApi.Core.Serialization.Models;
using EPiServer.Framework.Web;
using InertiaCore;
using OptimizelyCmsInertiaDemo.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddCmsAspNetCore()
    .AddContentDeliveryApi(options =>
    {
        options.SiteDefinitionApiEnabled = true;
        options.SetValidateTemplateForContentUrl(true);
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
