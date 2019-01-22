using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASP.NET_FinalProject.Models
{
    public class Tag
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name ="Tag name")]
        public string TagName { get; set; }

        public IEnumerable<Blog> Blogs { get; set; }
    }
}