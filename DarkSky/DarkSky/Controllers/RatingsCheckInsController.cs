using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DarkSky.Models;

namespace DarkSky.Controllers
{
    public class RatingsCheckInsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: RatingsCheckIns
        public ActionResult Index()
        {
            var ratingsCheckIns = db.RatingsCheckIns.Include(r => r.DarkSkyLocation).Include(r => r.Observer);
            return View(ratingsCheckIns.ToList());
        }

        public ActionResult Rating()
        {
            var ratingsCheckIns = db.RatingsCheckIns.Include(r => r.DarkSkyLocation).Include(r => r.Observer);
            return View();
        }

        // GET: RatingsCheckIns/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RatingsCheckIn ratingsCheckIn = db.RatingsCheckIns.Find(id);
            if (ratingsCheckIn == null)
            {
                return HttpNotFound();
            }
            return View(ratingsCheckIn);
        }

        // GET: RatingsCheckIns/Create
        public ActionResult Create()
        {
            ViewBag.LocationId = new SelectList(db.DarkSkyLocations, "LocationId", "Name");
            ViewBag.UserId = new SelectList(db.Observers, "UserId", "FirstName");
            return View();
        }

        // POST: RatingsCheckIns/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RatingsId,UserId,LocationId,Rating,CheckIn")] RatingsCheckIn ratingsCheckIn)
        {
            if (ModelState.IsValid)
            {
                db.RatingsCheckIns.Add(ratingsCheckIn);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LocationId = new SelectList(db.DarkSkyLocations, "LocationId", "Name", ratingsCheckIn.LocationId);
            ViewBag.UserId = new SelectList(db.Observers, "UserId", "FirstName", ratingsCheckIn.UserId);
            return View(ratingsCheckIn);
        }

        // GET: RatingsCheckIns/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RatingsCheckIn ratingsCheckIn = db.RatingsCheckIns.Find(id);
            if (ratingsCheckIn == null)
            {
                return HttpNotFound();
            }
            ViewBag.LocationId = new SelectList(db.DarkSkyLocations, "LocationId", "Name", ratingsCheckIn.LocationId);
            ViewBag.UserId = new SelectList(db.Observers, "UserId", "FirstName", ratingsCheckIn.UserId);
            return View(ratingsCheckIn);
        }

        // POST: RatingsCheckIns/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RatingsId,UserId,LocationId,Rating,CheckIn")] RatingsCheckIn ratingsCheckIn)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ratingsCheckIn).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LocationId = new SelectList(db.DarkSkyLocations, "LocationId", "Name", ratingsCheckIn.LocationId);
            ViewBag.UserId = new SelectList(db.Observers, "UserId", "FirstName", ratingsCheckIn.UserId);
            return View(ratingsCheckIn);
        }

        // GET: RatingsCheckIns/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RatingsCheckIn ratingsCheckIn = db.RatingsCheckIns.Find(id);
            if (ratingsCheckIn == null)
            {
                return HttpNotFound();
            }
            return View(ratingsCheckIn);
        }

        // POST: RatingsCheckIns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RatingsCheckIn ratingsCheckIn = db.RatingsCheckIns.Find(id);
            db.RatingsCheckIns.Remove(ratingsCheckIn);
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
