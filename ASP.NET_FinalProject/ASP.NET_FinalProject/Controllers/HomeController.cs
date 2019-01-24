using ASP.NET_FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASP.NET_FinalProject.Models.ViewModels;

namespace ASP.NET_FinalProject.Controllers
{
    public class HomeController : Controller
    {
        ModelDbContext db = new ModelDbContext();

        public ActionResult Home()
        {
            HomePageViewModel model = new HomePageViewModel()
            {
                Model = db.Models.ToList(),
                ModelCategory = db.ModelCategories.ToList(),
                Clients = db.Clients.ToList(),
                Blogs = db.Blogs.ToList().Reverse<Blog>()
            };

            return View(model);
        }

        public ActionResult AboutUs()
        {
            AboutUsViewModel model = new AboutUsViewModel()
            {
                Clients = db.Clients.ToList(),
                Personals = db.Personal.ToList()
            };
            return View(model);
        }

        public ActionResult Projects()
        {
            return View();
        }
    }
}