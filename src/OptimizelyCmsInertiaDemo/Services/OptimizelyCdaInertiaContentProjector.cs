using EPiServer.ContentApi.Core.Serialization;
using EPiServer.ContentApi.Core.Serialization.Models;
using EPiServer.Core;
using EPiServer.Framework.Web;
using Microsoft.AspNetCore.Localization;

namespace OptimizelyCmsInertiaDemo.Services;

public class OptimizelyCdaInertiaContentProjector : IInertiaContentProjector
{
    private readonly IContentConverter _contentConverter;
    private readonly ContextModeResolver _contextModeResolver;

    public OptimizelyCdaInertiaContentProjector(
        IContentConverter contentConverter,
        ContextModeResolver contextModeResolver)
    {
        _contentConverter = contentConverter;
        _contextModeResolver = contextModeResolver;
    }

    public object Project(PageData page, HttpContext httpContext)
    {
        var language = page.Language?.Name ?? httpContext.Features.Get<IRequestCultureFeature>()?.RequestCulture.UICulture.Name;

        // TODO: verify package version signature for converter context type and constructor arguments.
        var converterContext = new ConverterContext(
            language,
            _contextModeResolver.CurrentMode,
            httpContext);

        ContentApiModel contentModel = _contentConverter.Convert(page, converterContext);

        return new
        {
            pageType = page.GetOriginalType().Name,
            content = contentModel,
            route = new
            {
                path = httpContext.Request.Path.Value ?? "/",
                language
            }
        };
    }
}
