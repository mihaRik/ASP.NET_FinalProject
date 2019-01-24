using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASP.NET_FinalProject.Models
{
    public class Project
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name ="Model name")]
        public string ModelName { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name ="Make up")]
        public string MakeUp { get; set; }

        [Required]
        [StringLength(100)]
        public string Photographer { get; set; }
    }
}