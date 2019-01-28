using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ASP.NET_FinalProject.Models;

namespace ASP.NET_FinalProject.Areas.Admin.Controllers
{
    public class SocialNetworkCategoryController : Controller
    {
        private ModelDbContext db = new ModelDbContext();

        // GET: Admin/SocialNetworkCategory
        public ActionResult Index()
        {
            return View(db.SocialNetworkCategories.ToList());
        }

        // GET: Admin/SocialNetworkCategory/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SocialNetworkCategory socialNetworkCategory = db.SocialNetworkCategories.Find(id);
            if (socialNetworkCategory == null)
            {
                return HttpNotFound();
            }
            return View(socialNetworkCategory);
        }

        // GET: Admin/SocialNetworkCategory/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/SocialNetworkCategory/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CategoryName,CategoryIcon")] SocialNetworkCategory socialNetworkCategory)
        {
            if (ModelState.IsValid)
            {
                db.SocialNetworkCategories.Add(socialNetworkCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(socialNetworkCategory);
        }

        // GET: Admin/SocialNetworkCategory/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SocialNetworkCategory socialNetworkCategory = db.SocialNetworkCategories.Find(id);
            if (socialNetworkCategory == null)
            {
                return HttpNotFound();
            }
            return View(socialNetworkCategory);
        }

        // POST: Admin/SocialNetworkCategory/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CategoryName,CategoryIcon")] SocialNetworkCategory socialNetworkCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(socialNetworkCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(socialNetworkCategory);
        }

        // GET: Admin/SocialNetworkCategory/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SocialNetworkCategory socialNetworkCategory = db.SocialNetworkCategories.Find(id);
            if (socialNetworkCategory == null)
            {
                return HttpNotFound();
            }
            return View(socialNetworkCategory);
        }

        // POST: Admin/SocialNetworkCategory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SocialNetworkCategory socialNetworkCategory = db.SocialNetworkCategories.Find(id);
            db.SocialNetworkCategories.Remove(socialNetworkCategory);
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
