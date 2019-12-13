using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DarkSky
{
    public class URLVariables
    {
        private static string destination = "45.7791341,-84.78968960000002";
        public static string Destination { get { return destination; } }

        private static string directionsKey = "AIzaSyC95EG4riAADzoArZPhKYRDGjz7Hz7RH3w";
        public static string DirectionsKey { get { return directionsKey; } }

        private static string geoKey = "AIzaSyAi9HzsrbzS7_cwiu-hlCgNRmdxPCIQYK8";
        public static string GeoKey { get { return geoKey; } }
    }
}