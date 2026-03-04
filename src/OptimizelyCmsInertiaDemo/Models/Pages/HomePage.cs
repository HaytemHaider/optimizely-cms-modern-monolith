using EPiServer.Core;
using EPiServer.DataAnnotations;

namespace OptimizelyCmsInertiaDemo.Models.Pages;

[ContentType(DisplayName = "Home Page", GUID = "4d052df0-a5e8-4319-8ed6-93fa226866f6", Description = "Inertia demo home page")]
public class HomePage : PageData
{
    public virtual string? Heading { get; set; }
    public virtual XhtmlString? Intro { get; set; }
    public virtual ContentReference? DemoSubPageLink { get; set; }
}
