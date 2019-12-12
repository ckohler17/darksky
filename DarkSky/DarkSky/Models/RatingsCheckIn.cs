using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DarkSky.Models
{
    public class RatingsCheckIn
    {
        [Key]        
        public int RatingsId { get; set; }
                
        [ForeignKey("Observer")]
        public int UserId { get; set; }
        public Observer Observer { get; set; }
                
        [ForeignKey("DarkSkyLocation")]
        public int LocationId { get; set; }
        public DarkSkyLocation DarkSkyLocation { get; set; }

        [Display(Name = "Rating")]
        public int Rating { get; set; }

        [Display(Name = "CheckIn")]
        public DateTime CheckIn { get; set; }
    }
}