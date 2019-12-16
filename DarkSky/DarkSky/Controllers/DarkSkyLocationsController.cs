﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DarkSky.Models;
using Microsoft.AspNet.Identity;

namespace DarkSky.Controllers
{
    public class DarkSkyLocationsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: DarkSkyLocations
        public ActionResult Index()
        {
            return View(db.DarkSkyLocations.ToList());
        }

        // GET: DarkSkyLocations/Details/5
        public ActionResult Details(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DarkSkyLocation darkSkyLocations = db.DarkSkyLocations.Find(id);
            darkSkyLocations.AverageRating = AverageRating(darkSkyLocations);
            if (darkSkyLocations == null)
            {
                return HttpNotFound();
            }
            return View(darkSkyLocations);
        }

        // GET: DarkSkyLocations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DarkSkyLocations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,StreetAddress,City,State,ZipCode")] DarkSkyLocation darkSkyLocations)
        {
            if (ModelState.IsValid)
            {
                db.DarkSkyLocations.Add(darkSkyLocations);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(darkSkyLocations);
        }

        // GET: DarkSkyLocations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DarkSkyLocation darkSkyLocations = db.DarkSkyLocations.Find(id);
            if (darkSkyLocations == null)
            {
                return HttpNotFound();
            }
            return View(darkSkyLocations);
        }

        // POST: DarkSkyLocations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,StreetAddress,City,State,ZipCode")] DarkSkyLocation darkSkyLocations)
        {
            if (ModelState.IsValid)
            {
                db.Entry(darkSkyLocations).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(darkSkyLocations);
        }

        // GET: DarkSkyLocations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DarkSkyLocation darkSkyLocations = db.DarkSkyLocations.Find(id);
            if (darkSkyLocations == null)
            {
                return HttpNotFound();
            }
            return View(darkSkyLocations);
        }

        // POST: DarkSkyLocations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DarkSkyLocation darkSkyLocations = db.DarkSkyLocations.Find(id);
            db.DarkSkyLocations.Remove(darkSkyLocations);
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
        [HttpPost]
        public ActionResult Filter(string SelectByState)
        {
            var mylocation = db.DarkSkyLocations.Where(d => d.State == SelectByState).ToList();
            return View(mylocation);
        }
        public double AverageRating(DarkSkyLocation darkSkyLocation)
        {
            List<RatingsCheckIn> ratingsObj = new List<RatingsCheckIn>();
            List<string> ratings = new List<string>();
            List<int> integers = new List<int>();
            ratingsObj = db.RatingsCheckIns.Where(r => r.Rating > 0).Where(l => l.LocationId == darkSkyLocation.LocationId).ToList();
            foreach (RatingsCheckIn rating in ratingsObj)
            {
                Convert.ToInt32(rating.Rating);
                integers.Add(rating.Rating);
            }
            double averageRating = integers.Average();
            return averageRating;




        }
    }
    }
