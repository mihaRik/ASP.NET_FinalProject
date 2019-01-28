using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASP.NET_FinalProject.Models
{
    public class Client
    {
        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        public string Fullname { get; set; }

        [StringLength(50)]
        public string Title { get; set; }

        [Display(Name = "Success story")]
        public string SuccessStory { get; set; }

        [Range(0, 10)]
        public int Rating { get; set; }

        [Required]
        public string Photo { get; set; }
    }
}