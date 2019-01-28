using System.ComponentModel.DataAnnotations;

namespace ASP.NET_FinalProject.Models
{
    public class SocialNetwork
    {
        public int Id { get; set; }

        public string Link { get; set; }

        public int SocialNetworkCategoryId { get; set; }

        [Display(Name ="Social network category")]
        public SocialNetworkCategory SocialNetworkCategory { get; set; }

        [Display(Name ="Reference")]
        public int ReferenceId { get; set; }

        public PersonWithSocialNetwork PersonWithSocialNetwork { get; set; }
    }
}