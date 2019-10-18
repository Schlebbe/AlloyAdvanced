using EPiServer.DataAnnotations;
using System.ComponentModel.DataAnnotations;

namespace PracticeSite.Business.Site
{
    [GroupDefinitions]
    public static class SiteTabNames
    {
        [Display(Order = 10)]
        public const string EventInfo = "Event Info";
        [Display(Order = 10)]
        public const string PersonalInfo = "Personal Info";
        [Display(Order = 20)]
        public const string SEO = "SEO";
        [Display(Order = 30)]
        public const string SiteSettings = "Site Settings";
    }
}