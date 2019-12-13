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
        [Display(Name = "Street Number")]
        public string StreetNumber { get; set; }
        [Display(Name = "Street Name")]
        public string StreetName { get; set; }
        [Display(Name = "Street Suffix: St, Dr, Ln, etc.")]
        public string StreetSuffix { get; set; }
        [Display(Name = "City")]
        public string City { get; set; }
        [Display(Name = "State")]
        public string State { get; set; }
        [Display(Name = "Zip Code")]
        public string ZipCode { get; set; }


    }
}