using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.DynamicData;

namespace ASP.NET_FinalProject.Models
{
    [TableName("Personal")]
    public class Personal : PersonWithSocialNetwork
    {
        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        public string Fullname { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Profile photo")]
        public string PhotoUrl { get; set; }

        public IEnumerable<SocialNetwork> SocialNetworks { get; set; }
    }
}