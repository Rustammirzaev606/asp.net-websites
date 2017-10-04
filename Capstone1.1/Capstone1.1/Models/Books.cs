using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace Capstone1._1.Models
{
    public class Books
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }       
        public int ISBN { get; set; }
        public bool Available { get; set; }        
        public DateTime RequestDate { get; set; }
        public DateTime RequestExpDate { get; set; }
        public virtual Donator DonorID { get; set; }
    }
       
}