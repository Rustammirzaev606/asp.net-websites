using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace BookExchange3.Models
{
    public class Books
    {   
        [Key]            
        public int ID { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }

        public string Genre { get; set; }
        [Required]
        
        
        public double ISBN { get; set; }
        public bool? Available { get; set; }
        public bool? Taken { get; set; }

        public Books()
        {
            Available = false;
            Taken = false;
        }
    }
}