using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;

namespace AlloyAdvanced.Models.Blocks
{
    [ContentType(DisplayName = "PersonBlock", GUID = "d5fbcf09-7f87-4fb3-8f7b-5915090dba9d", Description = "")]
    public class PersonBlock : BlockData
    {
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual DateTime Birthday { get; set; }
        public virtual string Summary { get; set; }
    }
}