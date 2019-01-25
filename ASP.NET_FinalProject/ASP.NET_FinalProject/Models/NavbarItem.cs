using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ASP.NET_FinalProject.Models
{
    public class NavbarItem
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name ="Navbar item name")]
        public string NavItemName { get; set; }

        [Required]
        public string Url { get; set; }

        [Display(Name ="Allow dropdown")]
        public bool IsDropDown { get; set; }

        public IEnumerable<NavbarDropDownItem> NavbarDropDownItems { get; set; }
    }
}