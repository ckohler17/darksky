using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace DarkSky
{
    public class APITest
    {
        public async Task RunMethodAsync()
        {
            string url = "https://maps.googleapis.com/maps/api/directions/json?origin=45.7820689,-84.73227159999999&destination=45.7791341,-84.78968960000002&key=@APIKey.Key";
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);
            string jsonresult = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                LocationJsonInfo directionInfo = JsonConvert.DeserializeObject<LocationJsonInfo>(jsonresult);
            }
        }  
    }
}