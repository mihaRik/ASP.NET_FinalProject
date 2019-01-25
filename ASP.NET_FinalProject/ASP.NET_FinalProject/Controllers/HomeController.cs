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

        public ActionResult Models()
        {
            ModelsPageViewModel model = new ModelsPageViewModel()
            {
                Models = db.Models.ToList(),
                ModelCategories = db.ModelCategories.ToList()
            };

            return View(model);
        }

        public ActionResult Casting()
        {
            AboutUsViewModel model = new AboutUsViewModel()
            {
                Clients = db.Clients.ToList(),
                Personals = db.Personal.ToList()
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Casting(ContactUs contactUs)
        {
            db.Contacts.Add(contactUs);
            db.SaveChanges();

            return RedirectToAction("Casting");
        }

        public ActionResult Blog()
        {
            return View(db.Blogs.ToList());
        }

        public ActionResult SingleBlog(int id)
        {
            var blog = db.Blogs.Find(id);
            if (blog != null)
            {
                db.Blogs.Find(id).ViewCount++;
                db.SaveChanges();
            }

            SingleBlogViewModel model = new SingleBlogViewModel()
            {
                SingleBlog = db.Blogs.Find(id),
                Blogs = db.Blogs.ToList(),
                Tags = db.Tags.ToList(),
                BlogCategories = db.BlogCategories.ToList()
            };

            return View(model);
        }

        public ActionResult ContactUs()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ContactUs(ContactUs contactUs)
        {
            db.Contacts.Add(contactUs);
            db.SaveChanges();

            return RedirectToAction("ContactUs");
        }
    }
}