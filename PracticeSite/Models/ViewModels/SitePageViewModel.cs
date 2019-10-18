using EPiServer;
using EPiServer.Core;
using EPiServer.ServiceLocation;
using PracticeSite.Models.Pages;

namespace PracticeSite.Models.ViewModels
{
    // "out" is required so that we can pass a SitePageViewModel<StartPage> into a view
    // but declare it's layout to expect an ISitePageViewModel<SitePageData>
    // (only an interface can use the out declaration)
    public interface ISitePageViewModel<out T> where T : SitePageData
    {
        T CurrentPage { get; }
        StartPage HomePage { get; }
    }

    public class SitePageViewModel<T> : ISitePageViewModel<T> where T : SitePageData
    {
        public T CurrentPage { get; protected set; }

        public SitePageViewModel(T currentPage)
        {
            CurrentPage = currentPage;
        }

        // a read-only property will not appear in All Properties view
        // because it is not stored in the database.
        public StartPage HomePage
        {
            get
            {
                var loader = ServiceLocator.Current.GetInstance<IContentLoader>();
                if (!ContentReference.IsNullOrEmpty(ContentReference.StartPage))
                {
                    return loader.Get<StartPage>(ContentReference.StartPage);
                }
                return null;
            }
        }
    }
}