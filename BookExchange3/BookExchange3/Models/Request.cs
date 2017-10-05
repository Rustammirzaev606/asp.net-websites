using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace BookExchange3.Models
{
    public class Request
    {
        public int ID { get; set; }
        [Required]
        [Display(Name ="First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        [Required]
        
        public string Title { get; set; }
        [Required]
        
        public string Author { get; set; }
        [Required]
        
        public string Genre { get; set; }

        [Required]        
        public double ISBN { get; set; }
        public bool? Fullfilled { get; set; }


    }
}