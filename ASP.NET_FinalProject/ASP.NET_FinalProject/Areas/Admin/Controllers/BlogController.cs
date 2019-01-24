using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ASP.NET_FinalProject.Models;

namespace ASP.NET_FinalProject.Areas.Admin.Controllers
{
    public class BlogController : Controller
    {
        private ModelDbContext db = new ModelDbContext();

        // GET: Admin/Blog
        public ActionResult Index()
        {
            return View(db.Blogs.ToList());
        }

        // GET: Admin/Blog/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // GET: Admin/Blog/Create
        public ActionResult Create()
        {
            ViewBag.tags = db.Tags.ToList();
            ViewBag.blogCategory = db.BlogCategories.ToList();
            return View();
        }

        // POST: Admin/Blog/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Exclude = "BlogPhoto,SlidePhoto")] Blog blog, HttpPostedFileBase BlogPhoto, HttpPostedFileBase SlidePhoto)
        {
            if (SlidePhoto != null)
            {
                string blogSlidePhotoFullPath = Path.Combine(Server.MapPath("~/Uploads"), SlidePhoto.FileName);

                SlidePhoto.SaveAs(blogSlidePhotoFullPath);

                blog.SlidePhoto = "/Uploads/" + SlidePhoto.FileName;
            }
            blog.AddDate = DateTime.Now;

            string blogPhotoFullPath = Path.Combine(Server.MapPath("~/Uploads"), BlogPhoto.FileName);

            BlogPhoto.SaveAs(blogPhotoFullPath);

            blog.BlogPhoto = "/Uploads/" + BlogPhoto.FileName;

            db.Blogs.Add(blog);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Admin/Blog/Edit/5
        public ActionResult Edit(int? id)
        {
            ViewBag.tags = db.Tags.ToList();
            ViewBag.blogCategory = db.BlogCategories.ToList();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // POST: Admin/Blog/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Body,BlogPhoto,TagId,AddDate,Author,BlogCategoryId")] Blog blog)
        {
            if (ModelState.IsValid)
            {
                db.Entry(blog).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(blog);
        }

        // GET: Admin/Blog/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // POST: Admin/Blog/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Blog blog = db.Blogs.Find(id);
            db.Blogs.Remove(blog);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
