using System.ComponentModel.DataAnnotations;

namespace ASP.NET_FinalProject.Models
{
    public class NavbarDropDownItem
    {
        public int Id { get; set; }

        [Required]
        [Display(Name ="Navbar item id")]
        public int NavbarItemId { get; set; }

        [Display(Name ="Parent navbar item")]
        public NavbarItem NavbarItem { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name ="Dropdown item name")]
        public string NavItemName { get; set; }

        [Required]
        public string Url { get; set; }
    }
}