using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP.NET_FinalProject.Models.ViewModels
{
    public class People
    {
        public IEnumerable<Client> Clients { get; set; }

        public IEnumerable<Model> Models { get; set; }

        public IEnumerable<Personal> Personals { get; set; }
    }
}