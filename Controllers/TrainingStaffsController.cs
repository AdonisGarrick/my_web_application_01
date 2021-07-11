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
    public class TrainingStaffsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TrainingStaffs
        public ActionResult Index()
        {
            return View(db.TrainingStaffs.ToList());
        }

        // GET: TrainingStaffs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrainingStaff trainingStaff = db.TrainingStaffs.Find(id);
            if (trainingStaff == null)
            {
                return HttpNotFound();
            }
            return View(trainingStaff);
        }

        // GET: TrainingStaffs/Create
        /* [Authorize(Roles = "Administrators")] */
        public ActionResult Create()
        {
            return View();
        }

        // POST: TrainingStaffs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        /* [Authorize(Roles = "Administrators")] */
        public ActionResult Create([Bind(Include = "ID,Name,Email")] TrainingStaff trainingStaff)
        {
            if (ModelState.IsValid)
            {
                db.TrainingStaffs.Add(trainingStaff);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(trainingStaff);
        }

        // GET: TrainingStaffs/Edit/5
        /* [Authorize(Roles = "Administrators, TrainingStaff, Trainer")] */
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrainingStaff trainingStaff = db.TrainingStaffs.Find(id);
            if (trainingStaff == null)
            {
                return HttpNotFound();
            }
            return View(trainingStaff);
        }

        // POST: TrainingStaffs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        /* [Authorize(Roles = "Administrators, TrainingStaff, Trainer")] */
        public ActionResult Edit([Bind(Include = "ID,Name,Email")] TrainingStaff trainingStaff)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trainingStaff).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(trainingStaff);
        }

        // GET: TrainingStaffs/Delete/5
        /* [Authorize(Roles = "Administrators")] */
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrainingStaff trainingStaff = db.TrainingStaffs.Find(id);
            if (trainingStaff == null)
            {
                return HttpNotFound();
            }
            return View(trainingStaff);
        }

        // POST: TrainingStaffs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        /* [Authorize(Roles = "Administrators")] */
        public ActionResult DeleteConfirmed(int id)
        {
            TrainingStaff trainingStaff = db.TrainingStaffs.Find(id);
            db.TrainingStaffs.Remove(trainingStaff);
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
