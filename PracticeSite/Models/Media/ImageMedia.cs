using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;

namespace PracticeSite.Models.Media
{
    [ContentType(
        DisplayName = "Image", 
        GUID = "cb14a056-491a-4a2c-9785-b45011b7c449", 
        Description = "Any image file.")]
    /*[MediaDescriptor(ExtensionString = "pdf,doc,docx")]*/
    public class ImageMedia : ImageData
    {
    }
}