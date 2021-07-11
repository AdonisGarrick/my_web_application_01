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
    public class TopicsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Topics
        public ActionResult Index()
        {
            var topics = db.Topics.Include(t => t.Course);
            return View(topics.ToList());
        }

        // GET: Topics/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Topic topic = db.Topics.Find(id);
            if (topic == null)
            {
                return HttpNotFound();
            }
            return View(topic);
        }

        // GET: Topics/Create
        /* [Authorize(Roles = "Administrators, TrainingStaff")] */
        public ActionResult Create()
        {
            ViewBag.cID = new SelectList(db.Courses, "cID", "cName");
            return View();
        }

        // POST: Topics/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        /* [Authorize(Roles = "Administrators, TrainingStaff")] */
        public ActionResult Create([Bind(Include = "tID,tName,description,cID")] Topic topic)
        {
            if (ModelState.IsValid)
            {
                db.Topics.Add(topic);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.cID = new SelectList(db.Courses, "cID", "cName", topic.cID);
            return View(topic);
        }

        // GET: Topics/Edit/5
        /* [Authorize(Roles = "Administrators, TrainingStaff, Trainer")] */
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Topic topic = db.Topics.Find(id);
            if (topic == null)
            {
                return HttpNotFound();
            }
            ViewBag.cID = new SelectList(db.Courses, "cID", "cName", topic.cID);
            return View(topic);
        }

        // POST: Topics/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        /* [Authorize(Roles = "Administrators, TrainingStaff, Trainer")] */
        public ActionResult Edit([Bind(Include = "tID,tName,description,cID")] Topic topic)
        {
            if (ModelState.IsValid)
            {
                db.Entry(topic).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.cID = new SelectList(db.Courses, "cID", "cName", topic.cID);
            return View(topic);
        }

        // GET: Topics/Delete/5
        /* [Authorize(Roles = "Administrators, TrainingStaff")]*/
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Topic topic = db.Topics.Find(id);
            if (topic == null)
            {
                return HttpNotFound();
            }
            return View(topic);
        }

        // POST: Topics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        /* [Authorize(Roles = "Administrators, TrainingStaff")]*/
        public ActionResult DeleteConfirmed(int id)
        {
            Topic topic = db.Topics.Find(id);
            db.Topics.Remove(topic);
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
