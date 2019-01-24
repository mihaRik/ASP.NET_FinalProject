using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASP.NET_FinalProject.Models
{
    public class Model
    {
        public int Id { get; set; }

        [Required]
        [Display(Name ="Profile photo")]
        public string ProfilePhoto { get; set; }

        [Required]
        [Display(Name ="Hover photo")]
        public string HoverPhoto { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        public string Surname { get; set; }

        [Display(Name ="Add date")]
        public DateTime AddDate { get; set; }

        [Required]
        [Range(0,100)]
        public int Age { get; set; }

        [Required]
        [Display(Name = "Model category")]
        public int ModelCategoryId { get; set; }
    }
}