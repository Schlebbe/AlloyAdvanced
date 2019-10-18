using System.Collections.Generic;
using EPiServer.Shell.ObjectEditing;

namespace PracticeSite.Business.UI
{
    public static class EventListOption
    {
        public const string ContentArea = "CA";
        public const string ListOfContentReferences = "LoCR";
        public const string ContentReferenceOfBlockFolder = "CRoBF";
    }

    public class EventListOptionSelectFactory : ISelectionFactory
    {
        public IEnumerable<ISelectItem> GetSelections(ExtendedMetadata metadata)
        {
            return new ISelectItem[]
                {
                    new SelectItem
                    {
                        Text = "ContentArea of EventBlocks",
                        Value = EventListOption.ContentArea
                    },
                    new SelectItem
                    {
                        Text = "List of References of EventBlocks",
                        Value = EventListOption.ListOfContentReferences
                    },
                    new SelectItem
                    {
                        Text = "ContentReference to a Folder of EventBlocks",
                        Value = EventListOption.ContentReferenceOfBlockFolder
                    }
                };
        }
    }
}