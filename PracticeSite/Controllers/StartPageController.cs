using System.Web.Mvc;
using EPiServer.Web.Mvc;
using PracticeSite.Models.Pages;
using PracticeSite.Models.ViewModels;

namespace PracticeSite.Controllers
{
    public class StartPageController : PageController<StartPage>
    {
        public ActionResult Index(StartPage currentPage)
        {
            var model = new SitePageViewModel<StartPage>(currentPage);
            return View(model);
        }
    }
}