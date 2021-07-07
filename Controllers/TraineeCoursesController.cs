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
    public class TraineeCoursesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TraineeCourses
        public ActionResult Index()
        {
            var traineeCourses = db.TraineeCourses.Include(t => t.Course).Include(t => t.Trainee);
            return View(traineeCourses.ToList());
        }

        // GET: TraineeCourses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TraineeCourse traineeCourse = db.TraineeCourses.Find(id);
            if (traineeCourse == null)
            {
                return HttpNotFound();
            }
            return View(traineeCourse);
        }

        // GET: TraineeCourses/Create
        public ActionResult Create()
        {
            ViewBag.cID = new SelectList(db.Courses, "cID", "cName");
            ViewBag.TraineeID = new SelectList(db.Trainees, "ID", "Location");
            return View();
        }

        // POST: TraineeCourses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "tcID,cID,TraineeID")] TraineeCourse traineeCourse)
        {
            if (ModelState.IsValid)
            {
                db.TraineeCourses.Add(traineeCourse);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.cID = new SelectList(db.Courses, "cID", "cName", traineeCourse.cID);
            ViewBag.TraineeID = new SelectList(db.Trainees, "ID", "Location", traineeCourse.TraineeID);
            return View(traineeCourse);
        }

        // GET: TraineeCourses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TraineeCourse traineeCourse = db.TraineeCourses.Find(id);
            if (traineeCourse == null)
            {
                return HttpNotFound();
            }
            ViewBag.cID = new SelectList(db.Courses, "cID", "cName", traineeCourse.cID);
            ViewBag.TraineeID = new SelectList(db.Trainees, "ID", "Location", traineeCourse.TraineeID);
            return View(traineeCourse);
        }

        // POST: TraineeCourses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "tcID,cID,TraineeID")] TraineeCourse traineeCourse)
        {
            if (ModelState.IsValid)
            {
                db.Entry(traineeCourse).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.cID = new SelectList(db.Courses, "cID", "cName", traineeCourse.cID);
            ViewBag.TraineeID = new SelectList(db.Trainees, "ID", "Location", traineeCourse.TraineeID);
            return View(traineeCourse);
        }

        // GET: TraineeCourses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TraineeCourse traineeCourse = db.TraineeCourses.Find(id);
            if (traineeCourse == null)
            {
                return HttpNotFound();
            }
            return View(traineeCourse);
        }

        // POST: TraineeCourses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TraineeCourse traineeCourse = db.TraineeCourses.Find(id);
            db.TraineeCourses.Remove(traineeCourse);
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
