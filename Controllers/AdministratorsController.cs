using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ASM_02.Models;

namespace ASM_02.Controllers
{
    public class AdministratorsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Administrators
        [Authorize(Roles = "Administrators")]
        public ActionResult Index()
        {
            return View(db.Administrators.ToList());
        }

        // GET: Administrators/Details/5
        [Authorize(Roles = "Administrators")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Administrators administrators = db.Administrators.Find(id);
            if (administrators == null)
            {
                return HttpNotFound();
            }
            return View(administrators);
        }

        // GET: Administrators/Create
        [Authorize(Roles = "Administrators")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Administrators/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrators")]
        public ActionResult Create([Bind(Include = "ID,Name,Email")] Administrators administrators)
        {
            if (ModelState.IsValid)
            {
                db.Administrators.Add(administrators);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(administrators);
        }

        // GET: Administrators/Edit/5
        [Authorize(Roles = "Administrators")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Administrators administrators = db.Administrators.Find(id);
            if (administrators == null)
            {
                return HttpNotFound();
            }
            return View(administrators);
        }

        // POST: Administrators/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrators")]
        public ActionResult Edit([Bind(Include = "ID,Name,Email")] Administrators administrators)
        {
            if (ModelState.IsValid)
            {
                db.Entry(administrators).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(administrators);
        }

        // GET: Administrators/Delete/5
        [Authorize(Roles = "Administrators")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Administrators administrators = db.Administrators.Find(id);
            if (administrators == null)
            {
                return HttpNotFound();
            }
            return View(administrators);
        }

        // POST: Administrators/Delete/5
        [Authorize(Roles = "Administrators")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Administrators administrators = db.Administrators.Find(id);
            db.Administrators.Remove(administrators);
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
