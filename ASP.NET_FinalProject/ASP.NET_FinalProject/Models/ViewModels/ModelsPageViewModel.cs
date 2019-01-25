using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP.NET_FinalProject.Models.ViewModels
{
    public class ModelsPageViewModel : LayoutViewModel
    {
        public IEnumerable<Model> Models { get; set; }

        public IEnumerable<ModelCategory> ModelCategories { get; set; }
    }
}