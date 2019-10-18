using EPiServer.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;

namespace AlloyAdvanced.Business.Validation
{
    public class AllowedEditorsAttribute : ValidationAttribute, IMetadataAware
    {
        public string[] Roles { get; set; }

        public NotAllowedAction NotAllowedAction { get; set; }

        public AllowedEditorsAttribute()
        {
        }

        public AllowedEditorsAttribute(string[] roles)
        {
            Roles = roles;
        }

        public AllowedEditorsAttribute(string[] roles, NotAllowedAction action)
        {
            Roles = roles;
            NotAllowedAction = action;
        }

        public void OnMetadataCreated(ModelMetadata metadata)
        {
            foreach (string role in Roles)
            {
                if (PrincipalInfo.CurrentPrincipal.IsInRole(role))
                    return;
            }

            if (NotAllowedAction == NotAllowedAction.Default)
            {
                metadata.ShowForEdit = false;
            }
            else if (NotAllowedAction == NotAllowedAction.Readonly)
            {
                metadata.IsReadOnly = true;
            }
        }
    }

    public enum NotAllowedAction
    {
        Default, // hidden
        Readonly
    }
}