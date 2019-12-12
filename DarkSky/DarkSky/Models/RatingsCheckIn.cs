using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DarkSky.Models
{
    public class RatingsCheckIn
    {
        public int RatingsId { get; set; }
        [Display(Name = "Rating")]
        public int Rating { get; set; }
        [Display(Name = "CheckIn")]
        public bool CheckIn { get; set; }
    }
}