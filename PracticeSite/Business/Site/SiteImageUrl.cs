using EPiServer.DataAnnotations;

namespace PracticeSite.Business.Site
{
    public class SiteImageUrlAttribute : ImageUrlAttribute
    {
        public SiteImageUrlAttribute() : 
            base("~/Static/gfx/PageTypes/MarkPageType.png") { }
    }
}