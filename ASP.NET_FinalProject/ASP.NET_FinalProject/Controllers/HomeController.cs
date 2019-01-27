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
            LayoutViewModel model = new LayoutViewModel();
            return View(model);
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

        public ActionResult Blog(int? id)
        {
            HomePageViewModel model = new HomePageViewModel();

            if (id == null)
            {
                model.Blogs = db.Blogs.ToList();
            }
            else
            {
                model.Blogs = db.Blogs.Where(x => x.BlogCategoryId == id).ToList();
            }

            return View(model);
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
            return View(new LayoutViewModel());
        }

        [HttpPost]
        public ActionResult ContactUs(ContactUs contactUs)
        {
            db.Contacts.Add(contactUs);
            db.SaveChanges();

            return RedirectToAction("ContactUs");
        }

        [HttpPost]
        public ActionResult Search(string q)
        {
            return RedirectToAction("SearchResult", new { q });
        }

        public ActionResult SearchResult(string q)
        {
            SearchResultViewModel model = new SearchResultViewModel()
            {
                ModelCategories = db.ModelCategories.ToList(),

                Blogs = db.Blogs
                .Where(x => x.Title.ToUpper().Contains(q.ToUpper()) ||
                            x.Body.ToUpper().Contains(q.ToUpper()) ||
                            x.Author.ToUpper().Contains(q.ToUpper()))
                .ToList(),

                Models = db.Models
                .Where(x => x.Name.ToUpper().Contains(q.ToUpper()) ||
                            x.Surname.ToUpper().Contains(q.ToUpper()))
                .ToList(),

                Personals = db.Personal
                .Where(x => x.Fullname.ToUpper().Contains(q.ToUpper()) ||
                            x.Title.ToUpper().Contains(q.ToUpper()))
                .ToList(),

                Query = q
            };

            return View(model);
        }
    }
}