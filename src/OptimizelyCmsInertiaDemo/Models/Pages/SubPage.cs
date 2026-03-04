using EPiServer.Core;
using EPiServer.DataAnnotations;

namespace OptimizelyCmsInertiaDemo.Models.Pages;

[ContentType(DisplayName = "Sub Page", GUID = "f0d24740-f261-4dab-9646-93c33e339f66", Description = "Inertia demo sub page")]
public class SubPage : PageData
{
    public virtual string? Heading { get; set; }
    public virtual XhtmlString? Body { get; set; }
}
