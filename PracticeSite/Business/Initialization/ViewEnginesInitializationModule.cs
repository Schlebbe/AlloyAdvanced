using System;
using System.Linq;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using System.Web.Mvc;

namespace PracticeSite.Business.Initialization
{
    [InitializableModule]
    [ModuleDependency(typeof(EPiServer.Web.InitializationModule))]
    public class ViewEnginesInitializationModule : IInitializableModule
    {
        public void Initialize(InitializationEngine context)
        {
            var razor = ViewEngines.Engines.SingleOrDefault(engine =>
                engine.GetType() == typeof(RazorViewEngine)) as RazorViewEngine;
            var paths = razor.ViewLocationFormats
                .Where(path => path.EndsWith("cshtml"))
                .ToList();
            paths.Add("~/Views/Pages/{0}.cshtml");
            paths.Add("~/Views/Blocks/{0}.cshtml");
            razor.ViewLocationFormats = paths.ToArray();
        }

        public void Uninitialize(InitializationEngine context) { }
    }
}