using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone1._2.Models
{
    public class books
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public int ISBN { get; set; }
        public bool Available { get; set; } = false;
        public bool Taken { get; set; } = false;


    }
}