using System.Web.Mvc;
using EPiServer.Web.Mvc;
using PracticeSite.Models.Pages;
using PracticeSite.Models.ViewModels;

namespace PracticeSite.Controllers
{
    public class StandardPageController : PageController<StandardPage>
    {
        public ActionResult Index(StandardPage currentPage)
        {
            var model = new SitePageViewModel<StandardPage>(currentPage);
            return View(model);
        }
    }
}