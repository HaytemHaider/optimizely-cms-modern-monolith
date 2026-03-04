using EPiServer.Core;
using EPiServer.Web.Mvc;
using InertiaCore;
using Microsoft.AspNetCore.Mvc;
using OptimizelyCmsInertiaDemo.Models.Pages;
using OptimizelyCmsInertiaDemo.Services;

namespace OptimizelyCmsInertiaDemo.Controllers;

public class HomePageController : PageController<HomePage>
{
    private readonly IInertiaContentProjector _projector;

    public HomePageController(IInertiaContentProjector projector)
    {
        _projector = projector;
    }

    public IActionResult Index(HomePage currentPage)
    {
        var projected = _projector.Project(currentPage, HttpContext);

        if (ShouldReturnJson(HttpContext.Request))
        {
            return new JsonResult(projected);
        }

        return Inertia.Render("Home", new
        {
            pageType = "HomePage",
            content = projected,
            links = new
            {
                subPageUrl = Url.ContentUrl(currentPage.DemoSubPageLink)
            }
        });
    }

    private static bool ShouldReturnJson(HttpRequest request)
    {
        var acceptJson = request.Headers.Accept.Any(x => x.Contains("application/json", StringComparison.OrdinalIgnoreCase));
        var hasGateHeader = request.Headers.TryGetValue("Routed-By-ContentApi", out var gate) && gate == "1";
        return acceptJson && hasGateHeader;
    }
}
