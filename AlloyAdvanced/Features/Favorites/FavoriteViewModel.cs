using EPiServer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlloyAdvanced.Features.Favorites
{
    public class FavoriteViewModel
    {
        public List<Favorite> Favorites { get; set; }
        public ContentReference CurrentPageContentReference { get; set; }
    }
}