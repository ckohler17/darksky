using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DarkSky
{
    public class APITest
    {
        public string CreateAddress()
        {
           //have to somehow connect to the model to be able to access these properties
            StringBuilder addressString = new StringBuilder();
            addressString.Append(streetNumber + "+" + streetName + "+" + streetSuffix + ",+" + city + "+" + state + "+" + zip);
            string concatString = addressString.ToString();
            return concatString;
        }
        public async Task GetDuration()
        {
            //query for user's street address, city, state then convert to lat/long, store in a variable
            var latlong = await GetLatLong();
            var key = URLVariables.DirectionsKey;
            string url = $"https://maps.googleapis.com/maps/api/directions/json?origin={latlong}&destination={URLVariables.Destination}&key={key}";
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);
            string jsonresult = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                LocationJsonInfo locationJsonInfo = JsonConvert.DeserializeObject<LocationJsonInfo>(jsonresult);
                var duration = locationJsonInfo.routes[0].legs[0].duration.value;
            }
        }
        public async Task<string> GetLatLong()
        {
            //query for user's street address, city, state then convert to y
            var key = URLVariables.GeoKey;
            string url = $"https://maps.googleapis.com/maps/api/geocode/json?address=1600+Amphitheatre+Parkway,+Mountain+View,+CA&key={key}";
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);
            string jsonresult = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                LatLongJsonInfo latLongJsonInfo = JsonConvert.DeserializeObject<LatLongJsonInfo>(jsonresult);
                var latlong = latLongJsonInfo.results[0].geometry.location;
                string lat = latlong.lat.ToString();
                string lng = latlong.lng.ToString();
                StringBuilder latLongString = new StringBuilder();
                latLongString.Append(lat + "," + lng);
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