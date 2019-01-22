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
    public class ModelCategoriesController : Controller
    {
        private ModelDbContext db = new ModelDbContext();

        // GET: Admin/ModelCategories
        public ActionResult Index()
        {
            return View(db.ModelCategories.ToList());

        }

        // GET: Admin/ModelCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModelCategory modelCategory = db.ModelCategories.Find(id);
            if (modelCategory == null)
            {
                return HttpNotFound();
            }
            return View(modelCategory);
        }

        // GET: Admin/ModelCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/ModelCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CategoryName")] ModelCategory modelCategory)
        {
            if (ModelState.IsValid)
            {
                db.ModelCategories.Add(modelCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(modelCategory);
        }

        // GET: Admin/ModelCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModelCategory modelCategory = db.ModelCategories.Find(id);
            if (modelCategory == null)
            {
                return HttpNotFound();
            }
            return View(modelCategory);
        }

        // POST: Admin/ModelCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CategoryName")] ModelCategory modelCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(modelCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(modelCategory);
        }

        // GET: Admin/ModelCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModelCategory modelCategory = db.ModelCategories.Find(id);
            if (modelCategory == null)
            {
                return HttpNotFound();
            }
            return View(modelCategory);
        }

        // POST: Admin/ModelCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ModelCategory modelCategory = db.ModelCategories.Find(id);
            db.ModelCategories.Remove(modelCategory);
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
