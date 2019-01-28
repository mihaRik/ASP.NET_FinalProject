using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP.NET_FinalProject.Models.ViewModels
{
    public class HomePageViewModel : LayoutViewModel
    {
        public IEnumerable<Model> Model { get; set; }

        public IEnumerable<ModelCategory> ModelCategory { get; set; }

        public IEnumerable<Client> Clients { get; set; }

        public IEnumerable<Blog> Blogs { get; set; }

        public IEnumerable<SocialNetwork> SocialNetworks { get; set; }

        public IEnumerable<SocialNetworkCategory> SocialNetworkCategories { get; set; }
    }
}