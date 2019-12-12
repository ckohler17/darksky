using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DarkSky
{
    public static class APIKey
    {
        private static string googleDirectionskey = "AIzaSyC95EG4riAADzoArZPhKYRDGjz7Hz7RH3w";
        private static string googleMapskey = "AIzaSyD5euXUd3fU36gSpFxDvvQhlFmwRVRLGzM";
        public static string GoogleMapsKey { get { return googleMapskey; } }
    }
}