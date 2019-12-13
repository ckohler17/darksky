using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DarkSky.Models
{
    public class DarkSkyLocation
    {
        [Key]
        public int LocationId { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "Street Address")]
        public string StreetAddress { get; set; }
        [Display(Name = "City")]
        public string City { get; set; }
        [Display(Name = "State")]
        public string State { get; set; }
        [Display(Name = "Zip Code")]
        public string ZipCode { get; set; }
        [Display(Name = "LatLong")]
        public string LatLong { get; set; }

        [Display(Name = "Average Rating")]
        public double? AverageRating { get; set; }
    }
}