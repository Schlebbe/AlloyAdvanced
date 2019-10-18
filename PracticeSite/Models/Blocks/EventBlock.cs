using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using PracticeSite.Business;
using PracticeSite.Business.Site;

namespace PracticeSite.Models.Blocks
{
    [ContentType(
        DisplayName = "Event",
        GUID = "aab33184-8d81-4172-ac89-8aec28be4aa0",
        Description = "Events have a title and description, and where and when they take place.")]
    public class EventBlock : BlockData
    {
        [CultureSpecific]
        [Display(
            Name = "Title",
            Description = "The title should be short.",
            GroupName = SiteTabNames.EventInfo,
            Order = 10)]
        public virtual string Title { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Description",
            Description = "The description should be longer.",
            GroupName = SiteTabNames.EventInfo,
            Order = 20)]
        public virtual string Description { get; set; }

        [Display(
            Name = "Where",
            Description = "This is the location of the event.",
            GroupName = SiteTabNames.EventInfo,
            Order = 30)]
        public virtual string Where { get; set; }

        [Display(
            Name = "When",
            Description = "This is when the event happens.",
            GroupName = SiteTabNames.EventInfo,
            Order = 40)]
        public virtual DateTime? When { get; set; }
    }
}