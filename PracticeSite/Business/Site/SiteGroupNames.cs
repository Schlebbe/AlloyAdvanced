using EPiServer.DataAnnotations;
using System.ComponentModel.DataAnnotations;

namespace PracticeSite.Business.Site
{
    [GroupDefinitions]
    public static class SiteGroupNames
    {
        [Display(Order = 100)]
        public const string PracticeSite = "Practice Site";
    }
}