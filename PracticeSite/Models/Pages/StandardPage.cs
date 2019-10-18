using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using PracticeSite.Business.Site;
using System;
using System.ComponentModel.DataAnnotations;

namespace PracticeSite.Models.Pages
{
    [ContentType(
        DisplayName = "Standard",
        GroupName = SiteGroupNames.PracticeSite,
        Order = 20, // standard page should be ordered after start page
        GUID = "316c6770-cfef-4e32-9980-9d6478fa6ad2", 
        Description = "The standard page has a main intro text and a main body.")]
    [SiteImageUrl]
    public class StandardPage : SitePageData
    {
        [Display(
            Name = "Blocks and pages",
            Description = "This area can contain any combination of blocks and pages, except start pages.",
            GroupName = SystemTabNames.Content,
            Order = 10)]
        [AllowedTypes(RestrictedTypes = new Type[] { typeof(StartPage) })]
        public virtual ContentArea BlocksAndPages { get; set; }
    }
}