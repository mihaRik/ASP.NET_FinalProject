using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ASP.NET_FinalProject.Models;
using ASP.NET_FinalProject.Models.ViewModels;

namespace ASP.NET_FinalProject.Areas.Admin.Controllers
{
    public class SocialNetworkController : Controller
    {
        private ModelDbContext db = new ModelDbContext();

        // GET: Admin/SocialNetwork
        public ActionResult Index()
        {
            var socialNetworks = db.SocialNetworks.Include(s => s.SocialNetworkCategory);
            return View(socialNetworks.ToList());
        }

        // GET: Admin/SocialNetwork/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SocialNetwork socialNetwork = db.SocialNetworks.Find(id);
            if (socialNetwork == null)
            {
                return HttpNotFound();
            }
            return View(socialNetwork);
        }

        // GET: Admin/SocialNetwork/Create
        public ActionResult Create()
        {
            People people = new People()
            {
                Models=db.Models.ToList(),
                Personals=db.Personal.ToList()
            };

            var prop = people.GetType().GetProperties();

            var g = prop[0].GetValue(people);

            ViewBag.people = people;

            ViewBag.SocialNetworkCategoryId = new SelectList(db.SocialNetworkCategories, "Id", "CategoryName");
            return View();
        }

        // POST: Admin/SocialNetwork/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Link,SocialNetworkCategoryId,ReferenceId")] SocialNetwork socialNetwork)
        {
            if (ModelState.IsValid)
            {
                db.SocialNetworks.Add(socialNetwork);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SocialNetworkCategoryId = new SelectList(db.SocialNetworkCategories, "Id", "CategoryName", socialNetwork.SocialNetworkCategoryId);
            return View(socialNetwork);
        }

        // GET: Admin/SocialNetwork/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SocialNetwork socialNetwork = db.SocialNetworks.Find(id);
            if (socialNetwork == null)
            {
                return HttpNotFound();
            }
            ViewBag.SocialNetworkCategoryId = new SelectList(db.SocialNetworkCategories, "Id", "CategoryName", socialNetwork.SocialNetworkCategoryId);
            return View(socialNetwork);
        }

        // POST: Admin/SocialNetwork/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Link,SocialNetworkCategoryId,ReferenceId")] SocialNetwork socialNetwork)
        {
            if (ModelState.IsValid)
            {
                db.Entry(socialNetwork).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SocialNetworkCategoryId = new SelectList(db.SocialNetworkCategories, "Id", "CategoryName", socialNetwork.SocialNetworkCategoryId);
            return View(socialNetwork);
        }

        // GET: Admin/SocialNetwork/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SocialNetwork socialNetwork = db.SocialNetworks.Find(id);
            if (socialNetwork == null)
            {
                return HttpNotFound();
            }
            return View(socialNetwork);
        }

        // POST: Admin/SocialNetwork/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SocialNetwork socialNetwork = db.SocialNetworks.Find(id);
            db.SocialNetworks.Remove(socialNetwork);
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
