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
        private static string googleGeoKey = "AIzaSyAi9HzsrbzS7_cwiu-hlCgNRmdxPCIQYK8";
        public static string GoogleMapsKey { get { return googleMapskey; } }
        public static string GoogleGeoKey { get { return googleGeoKey; } }
        public static string GoogleDirectionsKey { get { return googleDirectionskey; } }
    }
}