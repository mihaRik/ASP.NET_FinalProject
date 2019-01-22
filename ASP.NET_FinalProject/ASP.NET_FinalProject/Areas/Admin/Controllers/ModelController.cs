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
    public class ModelController : Controller
    {
        private ModelDbContext db = new ModelDbContext();

        // GET: Admin/Model
        public ActionResult Index()
        {
            return View(db.Models.ToList());
        }

        // GET: Admin/Model/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Model model = db.Models.Find(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // GET: Admin/Model/Create
        public ActionResult Create()
        {
            ViewBag.modelCategory = db.ModelCategories.ToList();
            return View();
        }

        // POST: Admin/Model/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Exclude = "ProfilePhoto,HoverPhoto")] Model model, HttpPostedFileBase ProfilePhoto, HttpPostedFileBase HoverPhoto)
        {
            model.AddDate = DateTime.Now;

            string profilePhotoFullPath = Path.Combine(Server.MapPath("~/Uploads"), ProfilePhoto.FileName);
            string hoverPhotoFullPath = Path.Combine(Server.MapPath("~/Uploads"), HoverPhoto.FileName);

            ProfilePhoto.SaveAs(profilePhotoFullPath);
            HoverPhoto.SaveAs(hoverPhotoFullPath);

            model.ProfilePhoto = "/Uploads/" + ProfilePhoto.FileName;
            model.HoverPhoto = "/Uploads/" + HoverPhoto.FileName;


            db.Models.Add(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Admin/Model/Edit/5
        public ActionResult Edit(int? id)
        {
            ViewBag.modelCategory = db.ModelCategories.ToList();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Model model = db.Models.Find(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // POST: Admin/Model/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ProfilePhoto,HoverPhoto,Name,Surname,AddDate,Age,ModelCategoryId")] Model model)
        {
            if (ModelState.IsValid)
            {
                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: Admin/Model/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Model model = db.Models.Find(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // POST: Admin/Model/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Model model = db.Models.Find(id);
            db.Models.Remove(model);
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
