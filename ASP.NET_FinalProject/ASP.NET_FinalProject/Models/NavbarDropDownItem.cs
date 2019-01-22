using System.ComponentModel.DataAnnotations;

namespace ASP.NET_FinalProject.Models
{
    public class NavbarDropDownItem
    {
        public int Id { get; set; }

        [Required]
        public int NavbarItemId { get; set; }

        [Required]
        [StringLength(100)]
        public string NavItemName { get; set; }

        [Required]
        public string Url { get; set; }
    }
}