using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using PracticeSite.Business;
using EPiServer.Web;
using PracticeSite.Business.Site;

namespace PracticeSite.Models.Blocks
{
    [ContentType(DisplayName = "Person", 
        GUID = "2149fa83-75cd-4a44-8e61-933137091149", 
        Description = "A block of information about a person.")]
    public class PersonBlock : BlockData
    {
        [Display(
            Name = "First Name",
            Description = "The person's given name, e.g. Bob.",
            GroupName = SiteTabNames.PersonalInfo,
            Order = 10)]
        public virtual string FirstName { get; set; }

        [Display(
            Name = "Last Name",
            Description = "The person's surname name, e.g. Smith.",
            GroupName = SiteTabNames.PersonalInfo,
            Order = 20)]
        public virtual string LastName { get; set; }

        [Display(
            Name = "Birth Date",
            Description = "The person's date of birth.",
            GroupName = SiteTabNames.PersonalInfo,
            Order = 30)]
        public virtual DateTime? BirthDate { get; set; }

        [Display(
            Name = "Summary",
            Description = "A brief synopsis of the person's background or accomplishments.",
            GroupName = SiteTabNames.PersonalInfo,
            Order = 40)]
        [UIHint(UIHint.Textarea)]
        public virtual string Summary { get; set; }
    }
}