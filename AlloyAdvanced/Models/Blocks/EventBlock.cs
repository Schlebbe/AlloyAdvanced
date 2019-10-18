using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;

namespace AlloyAdvanced.Models.Blocks
{
    [ContentType(DisplayName = "EventBlock", GUID = "26d9e058-819e-4ec0-9a4f-5050b181aa31", Description = "")]
    public class EventBlock : BlockData
    {
        public virtual string Title { get; set; }
        public virtual DateTime When { get; set; }
        public virtual string Where { get; set; }
        public virtual string Description { get; set; }
    }
}