using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;

namespace AlloyAdvanced.Models.Pages
{

    [SiteContentType(DisplayName = "Shipper",
AvailableInEditMode = false,
Description = "A templateless leaf page node to store shipper data.", GUID = "322701d7-2159-4bbe-9b1b-c2a5b0900d29")]
    [SiteImageUrl]
    public class ShipperPage : PageData
    {
        public virtual int ShipperID { get; set; }
        [StringLength(40)]
        public virtual string CompanyName { get; set; }
        [StringLength(24)]
        public virtual string Phone { get; set; }
        // properties to enrich the imported data
        public virtual string CostPerUnit { get; set; }
    }
}