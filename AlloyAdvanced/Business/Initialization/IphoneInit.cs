using System;
using System.Linq;
using AlloyAdvanced.Models.Pages;
using EPiServer;
using EPiServer.Core;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.ServiceLocation;

namespace AlloyAdvanced.Business.Initialization
{
    [InitializableModule]
    [ModuleDependency(typeof(EPiServer.Web.InitializationModule))]
    public class IphoneInit : IInitializableModule
    {
        public void Initialize(InitializationEngine context)
        {
            var contentEvents = ServiceLocator.Current.GetInstance<IContentEvents>();
            contentEvents.PublishedContent += IphoneChecker;
        }

        private void IphoneChecker(object sender, ContentEventArgs e)
        {
            var repo = ServiceLocator.Current.GetInstance<IContentRepository>();
            var finder = ServiceLocator.Current
            .GetInstance<IPageCriteriaQueryService>();
            int pageCount = 0;

            var criteria = new PropertyCriteriaCollection();
            criteria.Add(new PropertyCriteria
            {
                Type = PropertyDataType.LongString,
                Name = "PageName",
                Condition = EPiServer.Filters.CompareCondition.Contained,
                Value = "iphone"
            });
            criteria.Add(new PropertyCriteria
            {
                Type = PropertyDataType.LongString,
                Name = "MetaTitle",
                Condition = EPiServer.Filters.CompareCondition.Contained,
                Value = "iphone"
            });
            criteria.Add(new PropertyCriteria
            {
                Type = PropertyDataType.LongString,
                Name = "MetaDescription",
                Condition = EPiServer.Filters.CompareCondition.Contained,
                Value = "iphone"
            });
            PageDataCollection results = finder.FindPagesWithCriteria(
            ContentReference.RootPage as PageReference, criteria);
            foreach (SitePageData page in results)
            {
                var clone = page.CreateWritableClone() as SitePageData;
                clone.Name = page.Name.Replace("iphone", "[censored]");
                clone.MetaTitle = page.MetaTitle?.Replace("iphone", "[censored]");
                clone.MetaDescription =
                page.MetaDescription?.Replace("iphone", "[censored]");
                repo.Save(clone,
                EPiServer.DataAccess.SaveAction.CheckIn,
                EPiServer.Security.AccessLevel.NoAccess);
                pageCount++;
            }
           
        }

        public void Uninitialize(InitializationEngine context)
        {
            //Add uninitialization logic
        }
    }
}