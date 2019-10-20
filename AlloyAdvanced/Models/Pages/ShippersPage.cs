using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;

namespace AlloyAdvanced.Models.Pages
{
    [SiteContentType(DisplayName = "Shippers",
Description = "Displays a list of imported shippers.",
        GUID = "ad8956a2-4551-46bb-bc0f-b8b2d369b2d3")]
    [SiteImageUrl]
    [AvailableContentTypes(
Availability = EPiServer.DataAbstraction.Availability.Specific,
Include = new[] { typeof(ShipperPage) },
IncludeOn = new[] { typeof(StartPage) })]
    public class ShippersPage : SitePageData
    {
        public virtual int DefaultShipper { get; set; }
    }
}