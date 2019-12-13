using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DarkSky.Models
{
    public class ParentLocationRating
    {
        public DarkSkyLocation GetDarkSkyLocation { get; set; }
        public RatingsCheckIn RatingsCheckIn { get; set; }
    }
}