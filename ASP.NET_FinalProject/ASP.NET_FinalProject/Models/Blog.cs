﻿using System;
using System.ComponentModel.DataAnnotations;

namespace ASP.NET_FinalProject.Models
{
    public class Blog
    {
        public int Id { get; set; }

        [Required]
        [StringLength(250)]
        public string Title { get; set; }

        [Required]
        public string Body { get; set; }

        [Required]
        [Display(Name = "Photo")]
        public string BlogPhoto { get; set; }

        [Display(Name = "Slide photo")]
        public string SlidePhoto { get; set; }

        [Required]
        [Display(Name = "Tags")]
        public int TagId { get; set; }

        [Display(Name = "Add date")]
        public DateTime AddDate { get; set; }

        [Required]
        [StringLength(100)]
        public string Author { get; set; }

        [Required]
        [Display(Name = "Blog category")]
        public int BlogCategoryId { get; set; }

        [Display(Name = "Slide photo available")]
        public bool IsSlide { get; set; }

        [Display(Name = "Is featured blog")]
        public bool IsFeatured { get; set; }

        public string BlogLink
        {
            get { return "/Home/SingleBlog/" + Id; }
        }

        public int ViewCount { get; set; }
    }
}