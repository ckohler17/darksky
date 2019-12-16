using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using DarkSky.Models;
using GeoCodeJson;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json;

namespace DarkSky.Controllers
{
    public class ObserversController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Observers
        public ActionResult Index()
        {
            return View(db.Observers.ToList());
        }

        // GET: Observers/Details/5
        public ActionResult Details(int? id)
        {
        
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Observer observer = db.Observers.Find(id);
            if (observer == null)
            {
                return HttpNotFound();
            }
            return View(observer);
        }

        // GET: Observers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Observers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FirstName,LastName,StreetAddress,City,State,ZipCode")] Observer observer)
        {
            if (ModelState.IsValid)
            {
                string newuserid = User.Identity.GetUserId();
                observer.ApplicationId = newuserid; 
                db.Observers.Add(observer);
                db.SaveChanges();
                return RedirectToAction("Index","Home");
            }

            return View(observer);
        }

        // GET: Observers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Observer observer = db.Observers.Find(id);
            if (observer == null)
            {
                return HttpNotFound();
            }
            return View(observer);
        }

        // POST: Observers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserId,FirstName,LastName,StreetAddress,City,State,ZipCode")] Observer observer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(observer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(observer);
        }

        // GET: Observers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Observer observer = db.Observers.Find(id);
            if (observer == null)
            {
                return HttpNotFound();
            }
            return View(observer);
        }

        // POST: Observers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Observer observer = db.Observers.Find(id);
            db.Observers.Remove(observer);
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
        public async Task<string> GetGeoCodeCall(int? id) // Change address to lat/lng
        {
            //query for user's street address, city, state then convert to y
            Observer observer = db.Observers.Where(o => o.UserId == id).Single();
            var Geokey = APIKey.GoogleGeoKey; // Grab Google API key for Geocoding
            string url = $"https://maps.googleapis.com/maps/api/geocode/json?address=1600+Amphitheatre+Parkway,+Mountain+View,+CA&key={Geokey}";
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);
            string jsonresult = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                GeoCodeObject geoInfo = JsonConvert.DeserializeObject<GeoCodeObject>(jsonresult);
                var userLatitude = geoInfo.results[0].geometry.location.lat.ToString();
                var userLongitude = geoInfo.results[0].geometry.location.lng.ToString();
                StringBuilder latLongString = new StringBuilder();
                latLongString.Append(userLatitude + "," + userLongitude);
                string newString = latLongString.ToString();
                return newString;
            }
            else
            {
                string oops = "oops";
                return oops;
            }
        }
    }
}
