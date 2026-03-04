using EPiServer.ContentApi.Core.Configuration;
using EPiServer.ContentApi.Core.Internal;
using EPiServer.ContentApi.Core.Serialization;
using EPiServer.ContentApi.Core.Serialization.Internal;
using EPiServer.ContentApi.Core.Serialization.Models;
using EPiServer.Core;
using EPiServer.Framework.Web;
using EPiServer.Web;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Options;
using System.Globalization;

namespace OptimizelyCmsInertiaDemo.Services;

public class OptimizelyCdaInertiaContentProjector : IInertiaContentProjector
{
    private readonly IContentConverter _contentConverter;
    private readonly ContextModeResolver _contextModeResolver;
    private readonly ContentApiOptions _contentApiOptions;

    public OptimizelyCdaInertiaContentProjector(
        IContentConverter contentConverter,
        ContextModeResolver contextModeResolver,
        IOptions<ContentApiOptions> contentApiOptionsAccessor)
    {
        _contentConverter = contentConverter;
        _contextModeResolver = contextModeResolver;
        _contentApiOptions = contentApiOptionsAccessor.Value;
    }

    public object Project(PageData page, HttpContext httpContext)
    {
        var language = page.Language ?? httpContext.Features.Get<IRequestCultureFeature>()?.RequestCulture.UICulture;


        // TODO: verify package version signature for converter context type and constructor arguments.
        var converterContext = CreateConverterContext(page, httpContext, language);

        ContentApiModel contentModel = _contentConverter.Convert(page, converterContext);

        return new
        {
            pageType = page.PageTypeName,
            content = contentModel,
            route = new
            {
                path = httpContext.Request.Path.Value ?? "/",
                language
            }
        };
    }

    private ConverterContext CreateConverterContext(PageData currentPage, HttpContext httpContext, CultureInfo language)
    {
        var contextMode = ContextMode.Default;

        // Keep versionless reference unless you specifically need a workID/version
        var contentReference = currentPage.ContentLink.ToReferenceWithoutVersion();

        // Optional passthrough if you want your Inertia path to mimic CDA query semantics
        var select = httpContext.Request.Query.TryGetValue("select", out var selectValues)
            ? selectValues.ToString()
            : null;

        var expand = httpContext.Request.Query.TryGetValue("expand", out var expandValues)
            ? expandValues.ToString()
            : null;

        // Common demo default: expand all nested expandable properties if caller didn't specify
        if (string.IsNullOrWhiteSpace(expand))
        {
            expand = "*";
        }

        // Usually false for parity with normal page rendering; consider true for cache-friendly payloads
        var excludePersonalizedContent = false;

        return new ConverterContext(
            contentReference,
            language,
            _contentApiOptions,
            contextMode,
            select,
            expand,
            excludePersonalizedContent);
    }
}
