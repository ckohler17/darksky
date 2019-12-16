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
using Microsoft.AspNet.Identity;
using MoreLinq;
using Newtonsoft.Json;

namespace DarkSky.Controllers
{
    public class DarkSkyLocationsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();


        public async Task<int> GetDuration(Observer observer, DarkSkyLocation darkSkyLocation)
        {
            //Observer observerLoggedIn = db.Observers.Where(o => o.UserId == observer.UserId).FirstOrDefault();
            string userLatLong = observer.ObserverLatLong;
            string locationLatLong = darkSkyLocation.LatLong;
            var key = URLVariables.DirectionsKey;
            string url = $"https://maps.googleapis.com/maps/api/directions/json?origin={userLatLong}&destination={locationLatLong}&key={key}";
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);
            string jsonresult = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                LocationJsonInfo locationJsonInfo = JsonConvert.DeserializeObject<LocationJsonInfo>(jsonresult);
                int duration = locationJsonInfo.routes[0].legs[0].duration.value;
                return duration;
            }
            else
            {
                return 0;
            }
        }
        public async Task<Dictionary<DarkSkyLocation, int>> CalculateAllDurations()
        {
            string userLoggedInId = User.Identity.GetUserId();
            Observer observerLoggedIn = db.Observers.Where(o => o.ApplicationId == userLoggedInId).FirstOrDefault();
            Dictionary<DarkSkyLocation, int> locationsByDuration = new Dictionary<DarkSkyLocation, int>();
            foreach (DarkSkyLocation location in db.DarkSkyLocations)
            {              
                var duration = await GetDuration(observerLoggedIn, location);
                locationsByDuration.Add(location, duration);           
            }

            return locationsByDuration;
        }
        public async Task<ActionResult> DisplayLowestDurationLocation()
        {       
            Dictionary<DarkSkyLocation, int> locationsByDuration = new Dictionary<DarkSkyLocation, int>();
            locationsByDuration = await CalculateAllDurations();
            var locationKey = locationsByDuration.MinBy(l => l.Value).Key;        
            return View("SeeNearest", locationKey );
        }
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
            db.SaveChanges();
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
        public ActionResult Edit(DarkSkyLocation darkSkyLocations)
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
