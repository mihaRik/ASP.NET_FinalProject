using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASP.NET_FinalProject.Models
{
    public class ContactUs
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100,ErrorMessage ="Long name. Please enter shorter")]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Resume { get; set; }
    }
}