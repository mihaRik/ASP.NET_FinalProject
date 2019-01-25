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
    public class NavbarItemController : Controller
    {
        private ModelDbContext db = new ModelDbContext();

        // GET: Admin/NavbarItem
        public ActionResult Index()
        {
            return View(db.NavbarItems.ToList());
        }

        // GET: Admin/NavbarItem/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NavbarItem navbarItem = db.NavbarItems.Find(id);
            if (navbarItem == null)
            {
                return HttpNotFound();
            }
            return View(navbarItem);
        }

        // GET: Admin/NavbarItem/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/NavbarItem/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NavItemName,Url,IsDropDown")] NavbarItem navbarItem)
        {
            if (ModelState.IsValid)
            {
                db.NavbarItems.Add(navbarItem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(navbarItem);
        }

        // GET: Admin/NavbarItem/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NavbarItem navbarItem = db.NavbarItems.Find(id);
            if (navbarItem == null)
            {
                return HttpNotFound();
            }
            return View(navbarItem);
        }

        // POST: Admin/NavbarItem/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NavItemName,Url,IsDropDown")] NavbarItem navbarItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(navbarItem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(navbarItem);
        }

        // GET: Admin/NavbarItem/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NavbarItem navbarItem = db.NavbarItems.Find(id);
            if (navbarItem == null)
            {
                return HttpNotFound();
            }
            return View(navbarItem);
        }

        // POST: Admin/NavbarItem/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NavbarItem navbarItem = db.NavbarItems.Find(id);
            db.NavbarItems.Remove(navbarItem);
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
