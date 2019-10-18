using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using PracticeSite.Business.Site;
using EPiServer.Web;

namespace PracticeSite.Models.Pages
{
    public abstract class SitePageData : PageData
    {
        [CultureSpecific]
        [Display(
            Name = "Main introduction",
            Description = "The main introduction appears in larger font above the main body.",
            GroupName = SystemTabNames.Content,
            Order = 10)]
        [UIHint(UIHint.Textarea)]
        public virtual string MainIntro { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Main body",
            Description = "The main body will be shown in the middle of the page, using the XHTML-editor you can insert for example text, images and tables.",
            GroupName = SystemTabNames.Content,
            Order = 20)]
        public virtual XhtmlString MainBody { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Title",
            Description = "The title appears on Google search results clipped to about 50 characters.",
            GroupName = SiteTabNames.SEO,
            Order = 10)]
        [StringLength(maximumLength: 60, MinimumLength = 5)]
        public virtual string MetaTitle { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Description",
            Description = "The description appears on Google search results as a summary of the page.",
            GroupName = SiteTabNames.SEO,
            Order = 20)]
        [Required]
        [UIHint(UIHint.Textarea)]
        public virtual string MetaDescription { get; set; }
    }
}