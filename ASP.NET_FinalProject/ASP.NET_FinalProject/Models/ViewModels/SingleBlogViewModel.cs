using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP.NET_FinalProject.Models.ViewModels
{
    public class SingleBlogViewModel : LayoutViewModel
    {
        public Blog SingleBlog { get; set; }

        public IEnumerable<Blog> Blogs { get; set; }

        public IEnumerable<BlogCategory> BlogCategories { get; set; }

        public IEnumerable<Tag> Tags { get; set; }
    }
}