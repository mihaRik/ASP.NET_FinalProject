using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP.NET_FinalProject.Models.ViewModels
{
    public abstract class LayoutViewModel
    {
        private static ModelDbContext db = new ModelDbContext();

        public IEnumerable<NavbarItem> navbarItems = db.NavbarItems.ToList();
    }
}