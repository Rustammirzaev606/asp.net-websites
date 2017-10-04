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
        
        public int ID { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public int ISBN { get; set; }
        public bool? Available { get; set; }
        public bool? Taken { get; set; }
        public Books()
        {
            Available = false;
            Available = false;

        }
    }
}