using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP.NET_FinalProject.Models.ViewModels
{
    public class SearchResultViewModel : LayoutViewModel
    {
        public IEnumerable<Blog> Blogs { get; set; }

        public IEnumerable<Model> Models { get; set; }

        public IEnumerable<Personal> Personals { get; set; }

        public IEnumerable<ModelCategory> ModelCategories { get; set; }

        public string Query { get; set; }
    }
}