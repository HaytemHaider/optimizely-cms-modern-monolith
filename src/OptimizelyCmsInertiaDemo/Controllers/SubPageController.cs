using EPiServer.Web.Mvc;
using InertiaCore;
using Microsoft.AspNetCore.Mvc;
using OptimizelyCmsInertiaDemo.Models.Pages;
using OptimizelyCmsInertiaDemo.Services;

namespace OptimizelyCmsInertiaDemo.Controllers;

public class SubPageController : PageController<SubPage>
{
    private readonly IInertiaContentProjector _projector;

    public SubPageController(IInertiaContentProjector projector)
    {
        _projector = projector;
    }

    public IActionResult Index(SubPage currentPage)
    {
        var projected = _projector.Project(currentPage, HttpContext);

        if (ShouldReturnJson(HttpContext.Request))
        {
            return new JsonResult(projected);
        }

        return Inertia.Render("SubPage", new
        {
            pageType = "SubPage",
            content = projected,
            links = new
            {
                homeUrl = "/"
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
