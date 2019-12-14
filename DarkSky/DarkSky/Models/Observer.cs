using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DarkSky.Models
{
    public class Observer 
    {
        [Key]
        public int UserId { get; set; }
        [Display(Name = "First Name")]        
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Street Address")]
        public string StreetAddress{ get; set; }
        
        [Display(Name = "City")]
        public string City { get; set; }
        [Display(Name = "State")]
        public string State { get; set; }
        [Display(Name = "Zip Code")]
        public string ZipCode { get; set; }
        public string ObserverLatLong { get; set; }
    }
}