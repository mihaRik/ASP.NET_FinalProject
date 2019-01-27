using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASP.NET_FinalProject.Models
{
    public class BlogCategory
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Category name")]
        public string CategoryName { get; set; }

        public IEnumerable<Blog> Blogs { get; set; }

        public string BlogCategoryLink
        {
            get { return "/Home/Blog/" + Id; }
        }
    }
}