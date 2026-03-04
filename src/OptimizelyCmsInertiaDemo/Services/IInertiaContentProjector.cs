using EPiServer.Core;

namespace OptimizelyCmsInertiaDemo.Services;

public interface IInertiaContentProjector
{
    object Project(PageData page, HttpContext httpContext);
}
