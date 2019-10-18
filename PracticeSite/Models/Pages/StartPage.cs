using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using System.Collections.Generic;
using EPiServer.Web;
using System;
using PracticeSite.Models.Blocks;
using EPiServer.Shell.ObjectEditing;
using PracticeSite.Business.Site;
using PracticeSite.Business.UI;
using PracticeSite.Business;

namespace PracticeSite.Models.Pages
{
    [ContentType(
        DisplayName = "Start",
        GroupName = SiteGroupNames.PracticeSite,
        Order = 10,
        GUID = "96c5d3ab-ae60-4022-bbbb-2339433ef715",
        Description = "This is the home page for the site. It has settings that apply to the shared site layout.")]
    [SiteImageUrl]
    public class StartPage : SitePageData
    {
        [Display(
            Name = "Branding logo",
            Description = "This should be an image displayed in the footer as branding.",
            GroupName = SiteTabNames.SiteSettings,
            Order = 10)]
        [UIHint(UIHint.Image)] // restricts asset picker to images
        public virtual ContentReference Logo { get; set; }

        [Display(
            Name = "Contact e-mail",
            Description = "This e-mail will be used by visitors to contact the web site owner.",
            GroupName = SiteTabNames.SiteSettings,
            Order = 20)]
        [RegularExpression(@"[a-zA-Z0-9\.]+@[a-zA-Z0-9\.]+",
            ErrorMessage = "You must enter a valid e-mail address.")]
        [RobertValidation]
        public virtual string ContactEmail { get; set; }

        [Display(
            Name = "Best bet page",
            Description = "This should point to a single page; it is shown in the footer.",
            GroupName = SiteTabNames.SiteSettings,
            Order = 30)]
        [AllowedTypes(typeof(StandardPage))]
        public virtual PageReference BestBet { get; set; }

        [Display(
            Name = "Favourite pages",
            Description = "This is a list of pages that will be shown as a menu in the footer.",
            GroupName = SiteTabNames.SiteSettings,
            Order = 40)]
        [AllowedTypes(
            AllowedTypes = new Type[] { typeof(SitePageData) },  // Allow any site pages (not blocks)...
            RestrictedTypes = new Type[] { typeof(StartPage) })] // ...except start pages
        public virtual IList<ContentReference> FavouritePagesMenu { get; set; }

        // The start page should show a list of events (instance of an EventBlock).
        // There are three common ways to store this:
        // 1. A content area restricted to contain only EventBlocks.
        // 2. An IList of ContentReferences restricted to contain only EventBlocks.
        // 3. A content reference to a block folder.

        [Display(
            Name = "Event list option",
            Description = "Select which of three common property types to store and render the event list.",
            GroupName = SiteTabNames.EventInfo,
            Order = 10)]
        [SelectOne(SelectionFactoryType = typeof(EventListOptionSelectFactory))]
        public virtual string EventListOption { get; set; }

        [Display(
            Name = "Event list",
            Description = "This is a list of events shown in the middle of the page below the main body.",
            GroupName = SiteTabNames.EventInfo,
            Order = 20)]
        [AllowedTypes(typeof(EventBlock))]
        public virtual ContentArea EventListContentArea { get; set; }

        [Display(
            Name = "Event list",
            Description = "This is a list of events shown in the middle of the page below the main body.",
            GroupName = SiteTabNames.EventInfo,
            Order = 30)]
        [AllowedTypes(typeof(EventBlock))]
        public virtual IList<ContentReference> EventListReferences { get; set; }

        [Display(
            Name = "Event list",
            Description = "This is a list of events shown in the middle of the page below the main body.",
            GroupName = SiteTabNames.EventInfo,
            Order = 40)]
        [UIHint(UIHint.BlockFolder)]
        public virtual ContentReference EventListFolder { get; set; }
    }
}