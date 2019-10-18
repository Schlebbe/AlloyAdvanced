using EPiServer.Core;
using EPiServer.PlugIn;
using EPiServer.Scheduler;
using EPiServer.ServiceLocation;
using EPiServer;

namespace PracticeSite.Business.ScheduledJobs
{
    [ScheduledPlugIn(DisplayName = "Change iWatch to Apple Watch")]
    public class AppleWatchJob : ScheduledJobBase
    {
        private bool _stopSignaled;

        public AppleWatchJob()
        {
            IsStoppable = true;
        }

        /// <summary>
        /// Called when a user clicks on Stop for a manually started job, or when ASP.NET shuts down.
        /// </summary>
        public override void Stop()
        {
            _stopSignaled = true;
        }

        /// <summary>
        /// Called when a scheduled job executes
        /// </summary>
        /// <returns>A status message to be stored in the database log and visible from admin mode</returns>
        public override string Execute()
        {
            OnStatusChanged(string.Format("Starting execution of {0}", this.GetType()));

            var repo = ServiceLocator.Current.GetInstance<IContentRepository>();

            var finder = ServiceLocator.Current.GetInstance<IPageCriteriaQueryService>();

            var criteria = new PropertyCriteriaCollection();

            criteria.Add(new PropertyCriteria
            {
                Type = PropertyDataType.LongString,
                Name = "MetaDescription",
                Condition = EPiServer.Filters.CompareCondition.Contained,
                Value = "iWatch"
            });

            criteria.Add(new PropertyCriteria
            {
                Type = PropertyDataType.LongString,
                Name = "MainIntro",
                Condition = EPiServer.Filters.CompareCondition.Contained,
                Value = "iWatch"
            });

            PageDataCollection results = 
                finder.FindPagesWithCriteria(ContentReference.RootPage as PageReference, criteria);

            foreach (PageData page in results)
            {
                //For long running jobs periodically check if stop is signaled and if so stop execution
                if (_stopSignaled)
                {
                    return "Stop of job was called";
                }


            }

            return "All content containing iWatch has been changed to Apple Watch.";
        }
    }
}
