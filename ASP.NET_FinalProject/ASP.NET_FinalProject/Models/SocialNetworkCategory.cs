using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASP.NET_FinalProject.Models
{
    public class SocialNetworkCategory
    {
        public int Id { get; set; }

        [Display(Name ="Category name")]
        public string CategoryName { get; set; }

        [Display(Name ="Category icon")]
        public string CategoryIcon { get; set; }

        public IEnumerable<SocialNetwork> SocialNetworks { get; set; }
    }
}