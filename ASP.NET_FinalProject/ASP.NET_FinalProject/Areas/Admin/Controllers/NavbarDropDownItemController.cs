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
    public class NavbarDropDownItemController : Controller
    {
        private ModelDbContext db = new ModelDbContext();

        // GET: Admin/NavbarDropDownItem
        public ActionResult Index()
        {
            var navbarDropDownItems = db.NavbarDropDownItems.Include(n => n.NavbarItem);
            return View(navbarDropDownItems.ToList());
        }

        // GET: Admin/NavbarDropDownItem/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NavbarDropDownItem navbarDropDownItem = db.NavbarDropDownItems.Find(id);
            if (navbarDropDownItem == null)
            {
                return HttpNotFound();
            }
            return View(navbarDropDownItem);
        }

        // GET: Admin/NavbarDropDownItem/Create
        public ActionResult Create()
        {
            ViewBag.NavbarItemId = new SelectList(db.NavbarItems, "Id", "NavItemName");
            return View();
        }

        // POST: Admin/NavbarDropDownItem/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NavbarItemId,NavItemName,Url")] NavbarDropDownItem navbarDropDownItem)
        {
            if (ModelState.IsValid)
            {
                db.NavbarDropDownItems.Add(navbarDropDownItem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.NavbarItemId = new SelectList(db.NavbarItems, "Id", "NavItemName", navbarDropDownItem.NavbarItemId);
            return View(navbarDropDownItem);
        }

        // GET: Admin/NavbarDropDownItem/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NavbarDropDownItem navbarDropDownItem = db.NavbarDropDownItems.Find(id);
            if (navbarDropDownItem == null)
            {
                return HttpNotFound();
            }
            ViewBag.NavbarItemId = new SelectList(db.NavbarItems, "Id", "NavItemName", navbarDropDownItem.NavbarItemId);
            return View(navbarDropDownItem);
        }

        // POST: Admin/NavbarDropDownItem/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NavbarItemId,NavItemName,Url")] NavbarDropDownItem navbarDropDownItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(navbarDropDownItem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.NavbarItemId = new SelectList(db.NavbarItems, "Id", "NavItemName", navbarDropDownItem.NavbarItemId);
            return View(navbarDropDownItem);
        }

        // GET: Admin/NavbarDropDownItem/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NavbarDropDownItem navbarDropDownItem = db.NavbarDropDownItems.Find(id);
            if (navbarDropDownItem == null)
            {
                return HttpNotFound();
            }
            return View(navbarDropDownItem);
        }

        // POST: Admin/NavbarDropDownItem/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NavbarDropDownItem navbarDropDownItem = db.NavbarDropDownItems.Find(id);
            db.NavbarDropDownItems.Remove(navbarDropDownItem);
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
