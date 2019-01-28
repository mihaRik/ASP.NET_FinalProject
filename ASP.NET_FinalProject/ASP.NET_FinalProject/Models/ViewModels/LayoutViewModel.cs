using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP.NET_FinalProject.Models.ViewModels
{
    public class LayoutViewModel
    {
        private static ModelDbContext db = new ModelDbContext();

        public IEnumerable<NavbarItem> NavbarItems { get; } = db.NavbarItems.ToList();

        public IEnumerable<NavbarDropDownItem> NavbarDropDownItems { get; } = db.NavbarDropDownItems.ToList();

        public IEnumerable<SocialNetwork> SocialNetworks { get; } = db.SocialNetworks.ToList();

        public IEnumerable<SocialNetworkCategory> SocialNetworkCategories { get; } = db.SocialNetworkCategories.ToList();
    }
}