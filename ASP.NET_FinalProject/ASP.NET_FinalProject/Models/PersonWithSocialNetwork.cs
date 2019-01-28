using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.NET_FinalProject.Models
{
    public interface PersonWithSocialNetwork
    {
        IEnumerable<SocialNetwork> SocialNetworks { get; set; }
    }
}
