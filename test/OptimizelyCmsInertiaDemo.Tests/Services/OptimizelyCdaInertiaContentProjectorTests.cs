using EPiServer.ContentApi.Core.Serialization;
using EPiServer.ContentApi.Core.Serialization.Models;
using EPiServer.Core;
using EPiServer.Framework.Web;
using Microsoft.AspNetCore.Http;
using Moq;
using OptimizelyCmsInertiaDemo.Services;
using Xunit;

namespace OptimizelyCmsInertiaDemo.Tests.Services;

public class OptimizelyCdaInertiaContentProjectorTests
{
    [Fact]
    public void Project_ShouldReturnAnonymousObjectContainingPageTypeAndRoute()
    {
        var contentConverter = new Mock<IContentConverter>();
        var contextModeResolver = new Mock<ContextModeResolver>();

        var page = new TestPageData();
        var httpContext = new DefaultHttpContext();
        httpContext.Request.Path = "/demo";

        contentConverter
            .Setup(x => x.Convert(It.IsAny<IContent>(), It.IsAny<ConverterContext>()))
            .Returns(new ContentApiModel());

        var sut = new OptimizelyCdaInertiaContentProjector(contentConverter.Object, contextModeResolver.Object);

        var payload = sut.Project(page, httpContext);

        Assert.NotNull(payload);
    }

    private sealed class TestPageData : PageData
    {
    }
}
